using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Messaging.Interfaces;
using TaskManager.Application.Messaging.Models;
using TaskManager.Application.RepositoryInterfaces;
using TaskManager.Domain.Models;

namespace TaskManager.Application.Messaging.Handlers;

public class ActivateEventHandler(IServiceProvider serviceProvider) : IEventHandlerStrategy
{
    public async Task HandleEvent(UserUpdateEvent updateEvent)
    {
        using var scope = serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
        await repository.ChangeUserStatusAsync(updateEvent.UserId, RecordStatus.Active, new CancellationToken());
    }
}