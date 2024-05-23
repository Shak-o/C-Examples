using Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using UserManager.AdminPanel.Models;
using UserManager.Infrastructure.ApiClients;

namespace UserManager.AdminPanel.Controllers;

public class UserManagerController : BaseController
{
    private readonly IUserManagerApi _userManagerApi;
    public UserManagerController(IUserManagerApi userManagerApi, ILogger<BaseController> logger, ITokenValidator validator) : base(userManagerApi, logger, validator)
    {
        _userManagerApi = userManagerApi;
    }

    public async Task<IActionResult> Index(int page, CancellationToken cancellationToken)
    {
        var list = await _userManagerApi.GetUserListAsync(page, cancellationToken);
        
        return View("Index", list);
    }
}