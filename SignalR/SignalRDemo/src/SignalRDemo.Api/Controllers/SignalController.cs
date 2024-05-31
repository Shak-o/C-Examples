using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Api.Hubs;

namespace SignalRDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SignalController(IHubContext<TestHub, ITestHub> hubContext) : ControllerBase
{
     [HttpPost]
     public async Task DoThing()
     {
          await hubContext.Clients.All.DoDaThing(Guid.NewGuid().ToString());
     }
}