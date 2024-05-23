using RestEase;
using TaskManager.Application.Commands;
using TaskManager.Domain.ViewModels;

namespace TaskManager.Infrastructure.ApiClients;

public interface ITaskManagerClient
{
    [Post("/Task")]
    Task AddTaskAsync([Body]CreateTaskCommand request, CancellationToken cancellationToken);

    [Get("/Task/List")]
    Task<List<TaskViewModel>> GetTasksAsync(CancellationToken cancellationToken);

    [Put("/Task/Status")]
    Task UpdateTaskStatusAsync(int taskId, CancellationToken cancellationToken);
}