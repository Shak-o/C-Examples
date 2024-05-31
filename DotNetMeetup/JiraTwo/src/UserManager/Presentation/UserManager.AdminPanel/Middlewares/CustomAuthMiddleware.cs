using Infrastructure.Shared.Services;
using UserManager.AdminPanel.Helpers;

namespace UserManager.AdminPanel.Middlewares;

public class CustomAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;

    public CustomAuthMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _serviceProvider = serviceProvider;
    }

    public async Task Invoke(HttpContext context)
    {
        CheckIfAuthenticated(context);
        await _next(context);
    }

    private void CheckIfAuthenticated(HttpContext context)
    {
        using var scope = _serviceProvider.CreateScope();
        var validator = scope.ServiceProvider.GetRequiredService<ITokenValidator>();
        
        if (context == null)
            throw new Exception("Unauthorized");

        var authCookie = context.Request.GetCookie();

        if (string.IsNullOrEmpty(authCookie))
        {
            var path = context.Request.Path.ToString();
            if (path != "/Account/Index" && (!path.Contains("css", StringComparison.OrdinalIgnoreCase) && !path.EndsWith("js",StringComparison.OrdinalIgnoreCase)))
                context.Response.Redirect($"/Account/Index");
            return;
        }

        var isValid = validator.ValidateToken(authCookie, "UserManager.Admin");
        
        if (!isValid) 
            context.Response.Redirect($"Account/Index");
    }
}