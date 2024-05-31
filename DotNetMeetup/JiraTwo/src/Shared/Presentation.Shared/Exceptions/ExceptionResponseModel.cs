using System.Net;

namespace Presentation.Shared.Exceptions;

public record ExceptionResponseModel
{
    public string? Type { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? Field { get; set; }
    public string? Instance { get; set; }
}