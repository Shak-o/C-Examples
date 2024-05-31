using MediatR;
using UserManager.Application.RepositoryInterfaces;

namespace UserManager.Application.Commands.AccountCommands;

public class DeleteRequestHandler(IAccountRepository accountRepository) : IRequestHandler<DeleteAccountRequest>
{
    public Task Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
    {
        return accountRepository.DeleteAccountAsync(request.Id, cancellationToken);
    }
}