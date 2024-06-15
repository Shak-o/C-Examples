using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace AspireCustom.Lib;

public static class Extensions
{
    public static IResourceBuilder<ApiResource> AddApi(this IDistributedApplicationBuilder builder, string name, string url)
    {
        return builder.AddResource(new ApiResource(name, url));
    }
}