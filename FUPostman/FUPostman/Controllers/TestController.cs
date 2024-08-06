using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace FUPostman.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpPost("From")]
    public string TestForm([FromForm] FormTest data)
    {
        var serialized = JsonSerializer.Serialize(data);
        return serialized;
    }
}

public record FormTest
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}