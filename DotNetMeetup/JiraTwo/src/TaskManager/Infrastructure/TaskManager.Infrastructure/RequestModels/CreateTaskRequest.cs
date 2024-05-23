namespace TaskManager.Infrastructure.RequestModels;

public class CreateTaskRequest
{
    public int AuthorUserId { get; set; }
    public int AssignedUserId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public TaskType TaskType { get; set; }
}

public enum TaskType
{
    Epic,
    Story,
    Bug,
    Qa
}