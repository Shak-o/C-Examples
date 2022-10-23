using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace APIRetry.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        { 
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IHttpClientFactory _client;
        private readonly ILogger<WeatherForecastController> _logger;

        //private readonly IAsyncPolicy<HttpResponseMessage> _policy = Policy<HttpResponseMessage>
        //    .Handle<HttpRequestException>()
        //    .OrResult(x => x.StatusCode >= HttpStatusCode.InternalServerError)
        //    .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5));
        
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            if (Random.Shared.Next(10) > 5)
                return new BadRequestObjectResult("bad error") { StatusCode = 500 };
            

            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray());
        }

        [HttpGet("test")]
        public async Task<IEnumerable<WeatherForecast>> TestPoint()
        {
            using var client = _client.CreateClient("Test");
            //var result = await _policy.ExecuteAsync(() => client.GetAsync("WeatherForecast"));
            var result = await client.GetAsync("WeatherForecast");
            var stream = await result.Content.ReadAsStreamAsync();
            var convert = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(stream);

            return convert;
        }
    }
}