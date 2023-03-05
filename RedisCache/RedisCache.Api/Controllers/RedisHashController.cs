using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisCache.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisHashController : ControllerBase
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private const string HashKey = "MaHash";

        public RedisHashController(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        [HttpPost("SetHash")]
        public async Task SetHash(Dictionary<string, string> values) // Never do this in actual code
        {
            var db = _connectionMultiplexer.GetDatabase();
            foreach (var keyValue in values)
            {
                await db.HashSetAsync(HashKey, new HashEntry[] { new(keyValue.Key, keyValue.Value) });
            }
        }

        [HttpPost("SetNewKey")]
        public async Task SetNewKey(string key, Dictionary<string, string> values)
        {
            var db = _connectionMultiplexer.GetDatabase();
            foreach (var keyValue in values)
            {
                await db.HashSetAsync(key, new HashEntry[] { new(keyValue.Key, keyValue.Value) });
            }
        }

        [HttpGet("GetHash")]
        public async Task<Dictionary<string, string>> GetData(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var value = await db.HashGetAllAsync(key);
            var toReturn = value.ToDictionary<HashEntry, string, string>(hashEntry => hashEntry.Name, hashEntry => hashEntry.Value);
            return toReturn;
        }
    }
}
