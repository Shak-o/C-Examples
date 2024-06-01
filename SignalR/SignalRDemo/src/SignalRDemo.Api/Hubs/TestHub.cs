using Microsoft.AspNetCore.SignalR;
using StackExchange.Redis;

namespace SignalRDemo.Api.Hubs;

public class TestHub(IConnectionMultiplexer multiplexer) : Hub<ITestHub>
{
    public override Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        if (httpContext == default)
            throw new Exception();

        var sessionId = httpContext.Request.Query.First(x => x.Key == "sessionId").Value;
        var connectionId = Context.ConnectionId;
        var db = multiplexer.GetDatabase();
        db.StringSet(sessionId.First(), connectionId);
        return base.OnConnectedAsync();
    }
}