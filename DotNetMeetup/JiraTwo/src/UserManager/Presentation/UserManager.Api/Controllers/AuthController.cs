using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManager.Application.Commands.AuthCommands;

namespace UserManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("UsernamePassword")]
    public Task<string> AuthenticateByUserNameAndPassword(AuthenticateUsernamePassRequest request,
        CancellationToken cancellationToken)
        => mediator.Send(request, cancellationToken);
}