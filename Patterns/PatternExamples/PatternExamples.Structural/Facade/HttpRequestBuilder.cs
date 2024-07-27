namespace PatternExamples.Structural.Facade;

// this would make http request
public class HttpRequestBuilder
{
    private readonly HttpRequestMessage _httpRequest = new();
    public HttpRequestMessage Get() => _httpRequest;

    public HttpRequestBuilder AddObjectToBody(object smth)
    {
        // lazy
        return this;
    }
}