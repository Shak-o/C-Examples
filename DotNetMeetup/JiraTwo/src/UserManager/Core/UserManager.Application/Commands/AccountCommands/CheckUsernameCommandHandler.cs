using MediatR;
using UserManager.Application.RepositoryInterfaces;

namespace UserManager.Application.Commands.AccountCommands;

public class CheckUsernameCommandHandler(IAccountRepository repository) : IRequestHandler<CheckUsernameCommand, bool>
{
    public async Task<bool> Handle(CheckUsernameCommand request, CancellationToken cancellationToken)
    {
        return await repository.CheckUsernameAsync(request.Username, cancellationToken);
    }
}