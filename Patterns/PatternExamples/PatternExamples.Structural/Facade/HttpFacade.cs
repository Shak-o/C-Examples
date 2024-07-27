namespace PatternExamples.Structural.Facade;

public class HttpFacade
{
    private readonly HttpClientBuilder _httpClientBuilder = new();
    private readonly HttpRequestBuilder _httpRequestBuilder = new();

    public Task MakeRequest(object someObject)
    {
        var builder = _httpClientBuilder
            .ConfigureEndpoint("https://locahost:432")
            .ConfigureTimeout(TimeSpan.FromMilliseconds(100));

        var client = builder.GetClient();

        var httpReq = _httpRequestBuilder.AddObjectToBody(someObject).Get();

        return client.SendAsync(httpReq);
    }
}