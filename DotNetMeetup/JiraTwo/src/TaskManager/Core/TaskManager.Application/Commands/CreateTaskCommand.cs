using MediatR;
using TaskManager.Domain.Models;

namespace TaskManager.Application.Commands;

public class CreateTaskCommand : IRequest<int>
{
    public int AuthorUserId { get; set; }
    public int AssignedUserId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public TaskType TaskType { get; set; }
}
