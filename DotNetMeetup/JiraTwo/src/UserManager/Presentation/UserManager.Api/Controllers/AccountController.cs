using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManager.Application.Commands.AccountCommands;
using UserManager.Application.Queries;
using UserManager.Application.ViewModels;

namespace UserManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task CreateAccount(CreateAccountRequest request, CancellationToken cancellationToken)
        => mediator.Send(request, cancellationToken);

    [HttpGet("{page}")]
    public Task<List<UserViewModel>> GetAccounts(int page, CancellationToken cancellationToken)
        => mediator.Send(new GetPagedAccountsRequest() { Page = page }, cancellationToken);

    [HttpPut("{accountId}/status")]
    public Task<bool> UpdateAccountAsync(int accountId, CancellationToken cancellationToken)
        => mediator.Send(new ChangeStatusRequest() { AccountId = accountId }, cancellationToken);
}