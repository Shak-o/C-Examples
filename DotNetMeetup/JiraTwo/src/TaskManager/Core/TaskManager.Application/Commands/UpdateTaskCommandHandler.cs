using MediatR;
using TaskManager.Application.RepositoryInterfaces;
using TaskStatus = TaskManager.Domain.Models.TaskStatus;

namespace TaskManager.Application.Commands;

public class UpdateTaskCommandHandler(ITaskRepository repository) : IRequestHandler<UpdateTaskCommand>
{
    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        TaskStatus newStatus;
        var existingTask = await repository.GetTask(request.TaskId);

        newStatus = existingTask.Status switch
        {
            TaskStatus.Open => TaskStatus.InProgress,
            TaskStatus.InProgress => TaskStatus.Done,
            TaskStatus.Done => TaskStatus.InProgress,
            _ => TaskStatus.Open
        };

        existingTask.Status = newStatus;

        await repository.UpdateTask(existingTask);
    }
}