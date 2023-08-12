using Microsoft.AspNetCore.Mvc;

namespace IFrameXCookie.Client.Controllers;

public class OtherController : Controller
{
    public IActionResult Index()
    {
        var value = TempData["Test"]!;
        ViewBag.Data = value;
        return View();
    }
}