using Aspire.Hosting.ApplicationModel;

namespace AspireCustom.Lib;

public class ApiResource(string name, string url) : IResourceWithConnectionString, IResourceWithEnvironment, IResourceWithEndpoints
{
    public string Name { get; } = name;
    public ResourceAnnotationCollection Annotations { get; } = [];
    public ReferenceExpression ConnectionStringExpression =>
        ReferenceExpression.Create($"{url}");
}