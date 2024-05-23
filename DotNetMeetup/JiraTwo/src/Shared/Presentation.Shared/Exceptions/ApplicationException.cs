using System.Net;

namespace Presentation.Shared.Exceptions;

public class ApplicationException : BaseApiException
{
    public ApplicationException(string title, string details) : base(title, details)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }
}