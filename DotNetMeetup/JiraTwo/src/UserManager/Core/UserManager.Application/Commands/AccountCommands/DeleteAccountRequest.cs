using MediatR;

namespace UserManager.Application.Commands.AccountCommands;

public class DeleteAccountRequest : IRequest
{
    public int Id { get; set; }
}