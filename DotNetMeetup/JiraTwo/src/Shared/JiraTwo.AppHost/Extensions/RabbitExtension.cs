namespace JiraTwo.AppHost.Extensions;

public static class RabbitExtension
{
    private static IResourceBuilder<ParameterResource>? _queueName;
    private static IResourceBuilder<ParameterResource>? _routingKey;
    private static IResourceBuilder<ParameterResource>? _exchangeName;
    
    public static IDistributedApplicationBuilder SetupRabbitEnv(this IDistributedApplicationBuilder builder)
    {
        _queueName = builder.AddParameter("QueueName");
        _routingKey = builder.AddParameter("RoutingKey");
        _exchangeName = builder.AddParameter("ExchangeName");
        
        return builder;
    }
    
    public static IResourceBuilder<T> AddRabbitMqEnvironmentVariables<T>(this IResourceBuilder<T> resourceBuilder) where T : ProjectResource
    {
        resourceBuilder.WithEnvironment("QueueName", _queueName ?? throw new InvalidOperationException("Not configured"))
            .WithEnvironment("RoutingKey", _routingKey ?? throw new InvalidOperationException("Not configured"))
            .WithEnvironment("ExchangeName", _exchangeName ?? throw new InvalidOperationException("Not configured"));
        
        return resourceBuilder;
    }
}