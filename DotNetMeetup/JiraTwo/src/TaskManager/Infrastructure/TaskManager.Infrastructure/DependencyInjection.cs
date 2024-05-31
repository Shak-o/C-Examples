using Infrastructure.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestEase.HttpClientFactory;
using TaskManager.Application.ApiClientInterfaces;
using TaskManager.Infrastructure.ApiClients;
using TaskManager.Infrastructure.ApiClientWrappers;
using TaskManager.Infrastructure.Messaging;
using TaskManager.Infrastructure.Workers;

namespace TaskManager.Infrastructure;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHttpClient("AuthManagerClient",
            static client =>
            {
                client.BaseAddress = new("https+http://userManagerApi");
            }).UseWithRestEaseClient<IAuthManagerClient>();
        
        builder.Services.AddHttpClient("UserManagerClient",
            static client =>
            {
                client.BaseAddress = new("https+http://userManagerApi");
            }).UseWithRestEaseClient<IUserManagerClient>();

        
        builder.Services.AddHttpClient("TaskManagerClient",
            static client =>
            {
                client.BaseAddress = new("https+http://taskManagerApi");
            }).UseWithRestEaseClient<ITaskManagerClient>();
        
        builder.Services.AddScoped<ITokenValidator, TokenValidator>();
        builder.Services.AddScoped<ITaskManagerClientWrapper, TaskManagerWrapper>();
        
        return builder;
    }

    public static IHostApplicationBuilder AddUserManagerClient(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHttpClient("UserManagerClient",
            static client =>
            {
                client.BaseAddress = new("https+http://userManagerApi");
            }).UseWithRestEaseClient<IUserManagerClient>();

        builder.Services.AddScoped<IUserManagerClientWrapper, UserManagerWrapper>();

        return builder;
    }

    public static IHostApplicationBuilder AddRabbit(this IHostApplicationBuilder builder)
    {
        builder.AddRabbitMQClient("messaging");
        builder.Services.AddSingleton<IMessageReceiver, MessageReceiver>();
        builder.Services.AddHostedService<RabbitMqWorker>();

        return builder;
    }
}