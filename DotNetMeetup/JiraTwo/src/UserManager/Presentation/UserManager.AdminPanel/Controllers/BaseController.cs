using Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using UserManager.AdminPanel.Helpers;
using UserManager.Application.Commands.AuthCommands;
using UserManager.Domain.Models;
using UserManager.Infrastructure.ApiClients;

namespace UserManager.AdminPanel.Controllers;

public class BaseController : Controller
{
    private readonly IUserManagerApi _userManagerApi;
    private readonly ILogger<BaseController> _logger;
    private readonly ITokenValidator _tokenValidator;
    
    public BaseController(IUserManagerApi userManagerApi, ILogger<BaseController> logger, ITokenValidator tokenValidator)
    {
        _userManagerApi = userManagerApi;
        _logger = logger;
        _tokenValidator = tokenValidator;
        SetIsLoggedIn();
    }

    public IActionResult RedirectToLogin()
    {
        return Redirect($"Account/Index");
    }

    private void SetIsLoggedIn()
    {
       var authCookie = HttpContext?.Request?.GetCookie();

        if (string.IsNullOrEmpty(authCookie))
        {
            ViewBag.IsLoggedIn = false;
            return;
        }

        var checkResult = _tokenValidator.ValidateToken(authCookie, "UserManager.Admin");
        ViewBag.IsLoggedIn = checkResult;
    }
}