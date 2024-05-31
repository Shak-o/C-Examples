using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.Application.Messaging;
using TaskManager.Application.Messaging.Handlers;
using TaskManager.Application.Messaging.Interfaces;

namespace TaskManager.Application;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        
        builder.Services.AddTransient<DeleteEventHandler>();
        builder.Services.AddTransient<ActivateEventHandler>();
        builder.Services.AddSingleton<Func<string, IEventHandlerStrategy>>(serviceProvider => key =>
        {
            return key switch
            {
                "Delete" => serviceProvider.GetRequiredService<DeleteEventHandler>(),
                "Activate" => serviceProvider.GetRequiredService<ActivateEventHandler>(),
                _ => throw new KeyNotFoundException()
            };
        });
        builder.Services.AddSingleton<StrategyResolver>();
        
        return builder;
    }
}