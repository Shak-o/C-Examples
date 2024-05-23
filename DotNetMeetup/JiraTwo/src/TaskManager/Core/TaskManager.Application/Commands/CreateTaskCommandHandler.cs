using MediatR;
using TaskManager.Application.ApiClientInterfaces;
using TaskManager.Application.RepositoryInterfaces;
using TaskManager.Domain.Models;
using TaskStatus = TaskManager.Domain.Models.TaskStatus;

namespace TaskManager.Application.Commands;

public class CreateTaskCommandHandler(ITaskRepository repository, IUserManagerClientWrapper userManagerClient) : IRequestHandler<CreateTaskCommand, int>
{
    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new JiraTwoTask
        {
            Title = request.Title,
            Description = request.Description,
            AuthorUserId = request.AuthorUserId,
            AssignedUserId = request.AssignedUserId,
            TaskType = request.TaskType,
            Status = TaskStatus.Open
        };

        if (task.AssignedUserId != null)
        {
            var name = await userManagerClient.GetNameAsync((int)task.AssignedUserId, cancellationToken);
            task.AssigneeName = name;
        }
        await repository.CreateTaskAsync(task, cancellationToken);

        return task.Id;
    }
}