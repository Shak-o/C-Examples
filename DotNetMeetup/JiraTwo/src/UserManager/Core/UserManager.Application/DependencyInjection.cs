using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UserManager.Application;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return builder;
    } 
}