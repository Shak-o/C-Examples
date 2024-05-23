using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using UserManager.Application.InfrastructureInterfaces;

namespace UserManager.Infrastructure.Messaging;

public class MessagePublisher : IMessagePublisher
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IConfiguration _configuration;

    public MessagePublisher(IConnection connection, IConfiguration configuration)
    {
        _connection = connection;
        _configuration = configuration;
        _channel = _connection.CreateModel();

        SetupMessaging();
    }

    public void Publish(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: _configuration["ExchangeName"],
            routingKey: _configuration["RoutingKey"],
            basicProperties: null,
            body: body);
    }


    private void SetupMessaging()
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
        _channel.Close();
        _connection.Close();
    }
}