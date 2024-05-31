using System.Net;

namespace Presentation.Shared.Exceptions;

public class ObjectNotFoundException : BaseApiException
{
    public ObjectNotFoundException(string title, string details) : base(title, details)
    {
        Title = title;
        Details = details;
        StatusCode = HttpStatusCode.NotFound;
    }
}