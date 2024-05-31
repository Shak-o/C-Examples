using MediatR;

namespace TaskManager.Application.Commands;

public class UpdateTaskCommand : IRequest
{
    public int TaskId { get; set; }
}