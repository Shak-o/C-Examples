using Microsoft.EntityFrameworkCore;
using TaskManager.Application.RepositoryInterfaces;
using TaskManager.Domain.Models;
using TaskManager.Domain.ViewModels;
using TaskStatus = TaskManager.Domain.Models.TaskStatus;

namespace TaskManager.Persistence.Repositories;

public class TaskRepository(TaskManagerDbContext context) : ITaskRepository
{
    public Task<int> CreateTaskAsync(JiraTwoTask task, CancellationToken cancellationToken)
    {
        context.Tasks.Add(task);
        return context.SaveChangesAsync(cancellationToken);
    }

    public Task ChangeUserStatusAsync(int userId, RecordStatus recordStatus, CancellationToken cancellationToken)
    {
        return context.Tasks.Where(x => x.AssignedUserId == userId)
            .ExecuteUpdateAsync(y => y.SetProperty(tsk => tsk.RecordStatus, recordStatus), cancellationToken);
    }
    public Task<bool> CheckIfUserHaveActiveTasksAsync(int userId, CancellationToken cancellationToken)
    {
        return context.Tasks.AnyAsync(x => x.AssignedUserId == userId && x.RecordStatus == RecordStatus.Active, cancellationToken);
    }

    public Task<List<TaskViewModel>> GetTasksAsync()
    {
        return context.Tasks.Select(x => new TaskViewModel
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            TaskType = x.TaskType,
            Status = x.Status,
            AssigneeName = x.AssigneeName
        }).ToListAsync();
    }

    public Task<JiraTwoTask?> GetTask(int taskId)
    {
        return context.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == taskId);
    }

    public Task UpdateTask(JiraTwoTask task)
    {
        context.Tasks.Update(task);
        return context.SaveChangesAsync();
    }
    
}