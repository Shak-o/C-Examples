using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisCache.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisStringsController : ControllerBase
    {
        private static readonly ConnectionMultiplexer Redis = ConnectionMultiplexer.Connect(
            new ConfigurationOptions
            {
                EndPoints =
                {
                    "localhost:32768"
                },
                Password = "redispw"
            });

        [HttpPost("Set")]
        public async Task Check()
        {
            //await ConnectionMultiplexer.ConnectAsync("localhost:32768;password=redispwd");
            var db = Redis.GetDatabase();
            var pong = await db.PingAsync();
            db.StringSet("test2", 55);
        }

        [HttpGet("Get")]
        public string? GetData()
        {
            var db = Redis.GetDatabase();
            return db.StringGet("test2");
        }

        [HttpPost("Increment")]
        public async Task Increment()
        {
            var db = Redis.GetDatabase();
            await db.StringIncrementAsync("test2", 5);
        }
    }
}
