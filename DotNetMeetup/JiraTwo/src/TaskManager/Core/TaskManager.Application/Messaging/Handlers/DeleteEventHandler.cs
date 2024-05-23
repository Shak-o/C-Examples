using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Messaging.Interfaces;
using TaskManager.Application.Messaging.Models;
using TaskManager.Application.RepositoryInterfaces;
using TaskManager.Domain.Models;

namespace TaskManager.Application.Messaging.Handlers;

public class DeleteEventHandler(IServiceProvider serviceProvider) : IEventHandlerStrategy
{
    public async Task HandleEvent(UserUpdateEvent updateEvent)
    {
        var cancellationToken = new CancellationToken();
        using var scope = serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
        var haveRecords = await repository.CheckIfUserHaveActiveTasksAsync(updateEvent.UserId, cancellationToken);
        if (haveRecords)
        {
            await repository.ChangeUserStatusAsync(updateEvent.UserId, RecordStatus.Hidden, cancellationToken);
        }
    }
}