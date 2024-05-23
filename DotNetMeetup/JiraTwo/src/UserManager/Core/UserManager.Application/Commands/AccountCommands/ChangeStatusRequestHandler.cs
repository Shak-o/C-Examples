using System.Text.Json;
using MediatR;
using Presentation.Shared.Exceptions;
using UserManager.Application.InfrastructureInterfaces;
using UserManager.Application.Messaging;
using UserManager.Application.RepositoryInterfaces;
using UserManager.Domain.Models;

namespace UserManager.Application.Commands.AccountCommands;

public class ChangeStatusRequestHandler(IAccountRepository repository, IMessagePublisher messagePublisher) : IRequestHandler<ChangeStatusRequest, bool>
{
    public async Task<bool> Handle(ChangeStatusRequest request, CancellationToken cancellationToken)
    {
        var account = await repository.GetAccountAsync(request.AccountId, cancellationToken);
        if (account == null)
            throw new ObjectNotFoundException("AccountNotFound", "Requested account not found");

        account.Status = account.Status == AccountStatus.Active ? AccountStatus.Blocked : AccountStatus.Active;

        await repository.UpdateAccount(account, cancellationToken);
        var updateEvent = new UserUpdateEvent
        {
            UserId = account.UserId,
            AccountStatus = account.Status,
            UserStatus = account.User!.Status
        };

        var serialized = JsonSerializer.Serialize(updateEvent);

        messagePublisher.Publish(serialized);
        return true;
    }
}