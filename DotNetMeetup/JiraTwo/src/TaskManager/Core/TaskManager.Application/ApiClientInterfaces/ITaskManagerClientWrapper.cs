using TaskManager.Domain.ViewModels;

namespace TaskManager.Application.ApiClientInterfaces;

public interface ITaskManagerClientWrapper
{
    Task UpdateTaskAsync(int taskId);
    Task<List<TaskViewModel>> GetTasksAsync(CancellationToken cancellationToken);
}