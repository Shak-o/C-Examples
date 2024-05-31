using TaskManager.Application.ApiClientInterfaces;
using TaskManager.Application.Commands;
using TaskManager.Domain.ViewModels;
using TaskManager.Infrastructure.ApiClients;

namespace TaskManager.Infrastructure.ApiClientWrappers;

public class TaskManagerWrapper(ITaskManagerClient apiClient) : ITaskManagerClientWrapper
{
    public Task UpdateTaskAsync(int taskId)
    {
        return apiClient.UpdateTaskStatusAsync(taskId, new CancellationToken());
    }

    public Task<List<TaskViewModel>> GetTasksAsync(CancellationToken cancellationToken)
        => apiClient.GetTasksAsync(cancellationToken);
}