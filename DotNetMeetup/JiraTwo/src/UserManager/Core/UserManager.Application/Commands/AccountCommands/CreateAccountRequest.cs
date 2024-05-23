using MediatR;
using UserManager.Domain.Models;

namespace UserManager.Application.Commands.AccountCommands;

public class CreateAccountRequest : IRequest<int>
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public int RequesterUserId { get; set; }
    public AccountType AccountType { get; set; }
}