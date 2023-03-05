using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisCache.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisSetsController : ControllerBase
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

        private const string SetKey = "MaSet";

        [HttpPost("Add")]
        public async Task AddSet(string value)
        {
            var test = ConnectionMultiplexer.Connect("localhost:32768;password=redispwd");
            var db = Redis.GetDatabase();
            await db.SetAddAsync(SetKey, new RedisValue[] { value });
        }

        [HttpGet("GetAll")]
        public string[] GetSet()
        {
            var db = Redis.GetDatabase();
            var values = db.SetMembers(SetKey);
            return values.Select(x => x.ToString()).ToArray();
        }

        [HttpGet("GetOne")]
        public string GetOneFromSet(string key)
        {
            var db = Redis.GetDatabase();
            var value = db.SetMembers(SetKey);
            var check = value.First(x => x.ToString().Split(":")[1] == key); // TODO don't like this one

            return check.ToString();
        }
    }
}
