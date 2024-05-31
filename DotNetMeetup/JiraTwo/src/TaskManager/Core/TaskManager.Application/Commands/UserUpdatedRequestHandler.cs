using MediatR;
using TaskManager.Application.Messaging;
using TaskManager.Application.Messaging.Interfaces;
using TaskManager.Application.Messaging.Models;

namespace TaskManager.Application.Commands;

public class UserUpdatedRequestHandler (StrategyResolver strategyResolver) : IRequestHandler<HandleUserUpdateRequest>
{
    public async Task Handle(HandleUserUpdateRequest request, CancellationToken cancellationToken)
    {
        await strategyResolver.HandleEvent(request.UpdateRequest);
    }
}