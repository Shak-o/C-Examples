using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Presentation.Shared.Exceptions;

namespace Presentation.Shared.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
    
    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private async Task HandleException(HttpContext context, Exception ex)
    {
        ExceptionResponseModel responseModel;
        if (ex is BaseApiException convert)
        {
            responseModel = new ExceptionResponseModel
            {
                StatusCode = convert.StatusCode,
                Title = convert.Title,
                Description = convert.Details,
                Instance = context.Request.Path
            };
        }
        else
        {
            responseModel = new ExceptionResponseModel
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Title = "UnexpectedError",
                Description = "Unexpected error happened",
                Instance = context.Request.Path
            };
        }
        
        var serialized = JsonSerializer.Serialize(responseModel);
        context.Response.Headers["Content-Type"] = "application/json";
        context.Response.StatusCode = (int)responseModel.StatusCode;
        await context.Response.WriteAsync(serialized);
            
        _logger.LogInformation(ex, "Exception happened");
    }
}