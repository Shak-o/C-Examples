using System.Net.Sockets;
using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspireCustom.Lib;

public static class Extensions
{
    public static IResourceBuilder<ApiResource> AddApi(this IDistributedApplicationBuilder builder, string name)
    {
        var url = builder.Configuration.GetConnectionString(name);
        if (url == default)
            throw new InvalidOperationException($"Url is not configured for resource: {name}");
        
        var resource = new ApiResource(name, url);

        var build = builder.AddResource(resource);

        return build;
    }

    public static IHostApplicationBuilder AddHttpClient(this IHostApplicationBuilder builder, string name)
    {
        builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection(name));
        
        return builder;
    }
}