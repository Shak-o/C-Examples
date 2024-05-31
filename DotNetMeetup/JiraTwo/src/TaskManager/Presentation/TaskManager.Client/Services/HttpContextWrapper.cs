namespace TaskManager.Client.Services;

public class HttpContextWrapper(IHttpContextAccessor accessor) : IHttpContextWrapper
{
    public HttpContext? GetHttpContext() =>
        accessor.HttpContext;
}