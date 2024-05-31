using System.Net;

namespace Presentation.Shared.Exceptions;

public class BaseApiException : Exception
{
    public BaseApiException(string title, string details)
    {
        Title = title;
        Details = details;
    }
    public HttpStatusCode StatusCode { get; set; }
    public string Title { get; set; }
    public string? Details { get; set; }
}