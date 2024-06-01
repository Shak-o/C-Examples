using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Client.Models;
using SignalRDemo.Client.Services;

namespace SignalRDemo.Client.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;
    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.SessionId = Guid.NewGuid().ToString();
        ViewBag.ApiUrl = _configuration["services:api:http:0"]!;
        return View();
    }

    [HttpGet("/test")]
    public IActionResult Test([FromQuery]string message)
    {
        ViewBag.Test = message;
        ViewBag.SessionId = Guid.NewGuid().ToString();
        ViewBag.ApiUrl = _configuration["services:api:https:0"]!;
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}