using MediatR;
using UserManager.Domain.Models;

namespace UserManager.Application.Commands.AuthCommands;

public class AuthenticateUsernamePassRequest : IRequest<string>
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public AccountType AccountType { get; set; }
}