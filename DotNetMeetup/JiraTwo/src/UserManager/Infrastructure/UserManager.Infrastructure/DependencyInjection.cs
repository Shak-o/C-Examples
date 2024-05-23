using Infrastructure.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestEase.HttpClientFactory;
using UserManager.Application.InfrastructureInterfaces;
using UserManager.Infrastructure.ApiClients;
using UserManager.Infrastructure.Messaging;

namespace UserManager.Infrastructure;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHttpClient("UserManagerClient",
            static client =>
            {
                client.BaseAddress = new("https+http://userManagerApi");
            }).UseWithRestEaseClient<IUserManagerApi>();
        
        builder.Services.AddScoped<ITokenValidator, TokenValidator>();
     
        return builder;
    }

    public static IHostApplicationBuilder AddMessaging(this IHostApplicationBuilder builder)
    {
        builder.AddRabbitMQClient("messaging");
        builder.Services.AddScoped<IMessagePublisher, MessagePublisher>();
        return builder;
    }
}