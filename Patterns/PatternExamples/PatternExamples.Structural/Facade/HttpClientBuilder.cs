namespace PatternExamples.Structural.Facade;

public class HttpClientBuilder
{
    private readonly HttpClient _httpClient = new();

    public HttpClient GetClient() => _httpClient;

    public HttpClientBuilder ConfigureEndpoint(string endpoint)
    {
        _httpClient.BaseAddress = new Uri(endpoint);
        return this;
    }

    public HttpClientBuilder ConfigureTimeout(TimeSpan timeSpan)
    {
        _httpClient.Timeout = timeSpan;
        return this;
    }
}