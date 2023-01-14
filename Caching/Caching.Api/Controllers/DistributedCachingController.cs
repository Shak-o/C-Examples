using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace Caching.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributedCachingController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public DistributedCachingController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public List<string> GetForecasts()
        {
            var randomStuff = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = Random.Shared.Next(1, 1000),
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
                .ToList();

            foreach (var weatherForecast in randomStuff)
            {
                _distributedCache.Set(weatherForecast.Id.ToString(), Encoding.UTF8.GetBytes(weatherForecast.Summary!));
            }

            return randomStuff.Select(weatherForecast =>
                _distributedCache.Get(weatherForecast.Id.ToString()))
                .Select(test => Encoding.UTF8.GetString(test!))
                .ToList();
        }

    }
}
