using TaskManager.Domain.Models;
using TaskStatus = TaskManager.Domain.Models.TaskStatus;

namespace TaskManager.Domain.ViewModels;

public class TaskViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public TaskType TaskType { get; set; }
    public TaskStatus Status { get; set; }
    public string? AssigneeName { get; set; }
}