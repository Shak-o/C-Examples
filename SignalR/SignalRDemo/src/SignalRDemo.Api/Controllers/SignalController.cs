using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Api.Hubs;
using StackExchange.Redis;

namespace SignalRDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SignalController(IHubContext<TestHub, ITestHub> hubContext, IConnectionMultiplexer multiplexer) : ControllerBase
{
     [HttpPost]
     public async Task DoThing(string sessionId)
     {
          var db = multiplexer.GetDatabase();
          var connectionId = db.StringGet(sessionId);
          await hubContext.Clients.Client(connectionId).DoDaThing($"{DateTime.Now} - {connectionId} - {sessionId}");
     }
}