using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisCache.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisListsController : ControllerBase
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private const string ListKey = "MaList";
        public RedisListsController(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        [HttpPost("PushLeft")]
        public async Task PushLeft()
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.ListLeftPushAsync(new RedisKey(ListKey), new RedisValue[] { "First", "Second", "Thirds" }).ConfigureAwait(false);
        }

        [HttpPost("PushRight")]
        public async Task PushRight()
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.ListRightPushAsync(new RedisKey(ListKey), new RedisValue[] { "First", "Second", "Thirds" }).ConfigureAwait(false);
        }

        [HttpGet("PopLeft")]
        public async Task<string?> PopLeft()
        {
            var db = _connectionMultiplexer.GetDatabase();
            var value = await db.ListLeftPopAsync(new RedisKey(ListKey)).ConfigureAwait(false);
            return value;
        }

        [HttpPost("Search")]
        public long Search()
        {
            var db = _connectionMultiplexer.GetDatabase();
            var value = db.ListPosition(new RedisKey(ListKey), "First");
            return value;
        }
    }
}
