using TaskManager.Domain.Models;
using TaskManager.Domain.ViewModels;
using TaskStatus = TaskManager.Domain.Models.TaskStatus;

namespace TaskManager.Application.RepositoryInterfaces;

public interface ITaskRepository
{
    Task<int> CreateTaskAsync(JiraTwoTask task, CancellationToken cancellationToken);
    Task<bool> CheckIfUserHaveActiveTasksAsync(int userId, CancellationToken cancellationToken);
    Task ChangeUserStatusAsync(int userId, RecordStatus status, CancellationToken cancellationToken);
    Task<List<TaskViewModel>> GetTasksAsync();
    Task UpdateTask(JiraTwoTask task);
    Task<JiraTwoTask?> GetTask(int taskId);
}