using System.Text;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TaskManager.Application.Commands;
using TaskManager.Application.Messaging.Models;

namespace TaskManager.Infrastructure.Workers;

public class RabbitMqWorker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RabbitMqWorker> _logger;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IConfiguration _configuration;
    private bool _subscribed;
    private readonly string _exchangeName;
    private readonly string _routingKey;
    private readonly string _queueName;

    public RabbitMqWorker(IServiceProvider serviceProvider, ILogger<RabbitMqWorker> logger,
        IConfiguration configuration, IConnection connection)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _configuration = configuration;
        _connection = connection;
        _channel = _connection.CreateModel();

        _exchangeName = _configuration["ExchangeName"] ?? throw new InvalidOperationException("Settings not configured");
        _routingKey = _configuration["RoutingKey"] ?? throw new InvalidOperationException("Settings not configured");
        _queueName = _configuration["QueueName"] ?? throw new InvalidOperationException("Settings not configured");

        SetupDirectExchangeAndQueue();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                
                var evt = JsonSerializer.Deserialize<UserUpdateEvent>(message);
                try
                {
                    mediator.Send(new HandleUserUpdateRequest() { UpdateRequest = evt }).GetAwaiter().GetResult();
                    _channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _channel.BasicNack(ea.DeliveryTag, false, false);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not process message: {Message}", message);
            }
        };

        if (_subscribed)
        {
            _channel.BasicConsume(queue: _queueName,
                autoAck: false,
                consumer: consumer);
        }
        
        return Task.CompletedTask;
    }
    
    private void SetupDirectExchangeAndQueue()
    {
        try
        {
            _channel.ExchangeDeclare(exchange: _exchangeName, type: "direct");
            _channel.QueueDeclare(queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            _channel.QueueBind(queue: _queueName,
                exchange: _exchangeName,
                routingKey: _routingKey);
            
            _subscribed = true;
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
        catch (Exception ex)
        {
            _subscribed = false;
            _logger.LogError(ex, "Could not connect to rabbit");
        }
    }
}