using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace AspireCustom.Lib;

public class ApiResource(string name, string url) : IResourceWithConnectionString, IResourceWithEnvironment
{
    public string Name { get; } = name;
    public ResourceAnnotationCollection Annotations { get; } = new();
    public ReferenceExpression ConnectionStringExpression =>
        ReferenceExpression.Create($"{url}");
}