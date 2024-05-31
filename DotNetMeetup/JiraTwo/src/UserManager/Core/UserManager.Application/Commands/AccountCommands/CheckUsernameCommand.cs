using MediatR;

namespace UserManager.Application.Commands.AccountCommands;

public class CheckUsernameCommand : IRequest<bool>
{
    public required string Username { get; set; }
}