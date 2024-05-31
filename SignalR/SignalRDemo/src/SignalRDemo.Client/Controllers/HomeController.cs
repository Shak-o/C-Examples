using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Client.Models;
using SignalRDemo.Client.Services;

namespace SignalRDemo.Client.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IHubConnectionAccessor _connectionAccessor;
    public HomeController(ILogger<HomeController> logger, IHubConnectionAccessor connectionAccessor)
    {
        _logger = logger;
        _connectionAccessor = connectionAccessor;
    }

    public async Task<IActionResult> Index()
    {
        var res = await _connectionAccessor.Configure();
        ViewBag.Test = res;
        return View();
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