using Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using UserManager.Application.Commands.AuthCommands;
using UserManager.Domain.Models;
using UserManager.Infrastructure.ApiClients;

namespace UserManager.AdminPanel.Controllers;

public class AccountController : Controller
{
    private readonly IUserManagerApi _userManagerApi;
    private readonly ILogger<AccountController> _logger;
    private readonly ITokenValidator _validator;

    public AccountController(IUserManagerApi userManagerApi, ILogger<AccountController> logger, ITokenValidator validator)
    {
        _userManagerApi = userManagerApi;
        _logger = logger;
        _validator = validator;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(string username, string password, CancellationToken cancellationToken)
    {
        try
        {
            var token = await _userManagerApi.AuthenticateByUserNameAndPasswordAsync(new AuthenticateUsernamePassRequest()
            {
                AccountType = AccountType.Admin,
                UserName = username,
                Password = password
            }, cancellationToken).ConfigureAwait(false);

            if (HttpContext == null)
                throw new ApplicationException("Error happened");
            
            HttpContext.Response.Cookies.Append("AuthToken", token);

            return Redirect($"UserManager/UsersList/{0}");
        }
        catch (ApiException exception)
        {
            _logger.LogError(exception, exception.Content);
            return Redirect("/");
        }
    }
}