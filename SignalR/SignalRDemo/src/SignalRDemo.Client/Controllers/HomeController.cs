using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Client.Models;
using SignalRDemo.Client.Services;

namespace SignalRDemo.Client.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //private HubConnectionAccessor _connectionAccessor;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        // _connectionAccessor = connectionAccessor;
        // _connectionAccessor.OnMessageReceived += s =>
        // {
        //     ViewBag.Test = s;
        // };
    }

    public async Task<IActionResult> Index()
    {
        //await _connectionAccessor.StartConnection();
        return View();
    }

    [HttpGet("/test")]
    public IActionResult Test([FromQuery]string message)
    {
        ViewBag.Test = message;
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