using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text;

namespace RedisCache.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;

        private static readonly ConnectionMultiplexer Redis = ConnectionMultiplexer.Connect(
            new ConfigurationOptions
            {
                EndPoints =
                {
                    "localhost:32768"
                },
                Password = "redispw"
            });

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            try
            {
                var test = ConnectionMultiplexer.Connect("localhost:32768");
                var bytes = Encoding.UTF8.GetBytes("maa value");

                var db = Redis.GetDatabase();
                db.SetAdd("test", bytes);

                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                    .ToArray();
            }
            catch (Exception ex)
            {
                var db = Redis.GetDatabase();
                throw;
            }
        }

        [HttpGet("check")]
        public async Task<string> Check()
        {
            //await ConnectionMultiplexer.ConnectAsync("localhost:32768;password=redispwd");
            var db = Redis.GetDatabase();
            var pong = await db.PingAsync();
            db.StringSet("test1", new RedisValue("ma value"));
            var data = db.StringGet("test1");
            //var convert = Encoding.UTF8.GetString(data);
            return data;
        }
    }
}