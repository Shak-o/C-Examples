using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManager.Application.Queries;

namespace UserManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet("Name")]
    public Task<string> GetName(GetNameQuery query, CancellationToken cancellationToken)
        => mediator.Send(query, cancellationToken);
}