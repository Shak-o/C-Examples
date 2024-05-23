using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TaskManager.Application.Messaging.Models;

namespace TaskManager.Infrastructure.Messaging;

public class MessageReceiver : IMessageReceiver, IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IConfiguration _configuration;
    private readonly ILogger<MessageReceiver> _logger;
    public event Action<UserUpdateEvent> OnMessageReceived;
    
    public MessageReceiver(IConnection connection, IConfiguration configuration, ILogger<MessageReceiver> logger)
    {
        _connection = connection;
        _configuration = configuration;
        _logger = logger;
        _channel = _connection.CreateModel();
        
        SetupDirectExchangeAndQueue();
    }
    
    public void ReceiveMessage()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            try
            {
                var evt = JsonSerializer.Deserialize<UserUpdateEvent>(message);
                OnMessageReceived?.Invoke(evt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not process message: {Message}", message);
            }
        };

        _channel.BasicConsume(queue: _configuration["QueueName"],
            autoAck: true,
            consumer: consumer);
    }
    private void SetupDirectExchangeAndQueue()
    {
        var exchangeName = _configuration["ExchangeName"];
        var routingKey = _configuration["RoutingKey"];
        var queueName = _configuration["QueueName"];

        _channel.ExchangeDeclare(exchange: exchangeName, type: "direct");
        _channel.QueueDeclare(queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        _channel.QueueBind(queue: queueName,
            exchange: exchangeName,
            routingKey: routingKey);
    }

    public void Dispose()
    {
        if (!_channel.IsOpen) return;
        _channel.Close();
        _connection.Close();
    }
}