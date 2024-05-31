using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Models;

public class JiraTwoTask : BaseEntity
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public int AuthorUserId { get; set; }
    public int? AssignedUserId { get; set; }
    public string? AssigneeName { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<JiraTwoTask>? SubTasks { get; set; }
    public TaskType TaskType { get; set; }
    public TaskStatus Status { get; set; }
    public RecordStatus RecordStatus { get; set; }
}

public enum RecordStatus
{
    Active,
    Hidden
}
public enum TaskStatus
{
    Open,
    InProgress,
    Done,
    Removed
}

public enum TaskType
{
    Epic,
    Story,
    Bug,
    Qa
}