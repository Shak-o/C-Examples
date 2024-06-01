using Microsoft.AspNetCore.Mvc;

namespace SignalRDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    [HttpPost]
    public async Task AddSession()
    {
        
    }
}