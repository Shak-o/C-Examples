using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;
using TaskManager.Application.Queries;
using TaskManager.Domain.ViewModels;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task AddTask(CreateTaskCommand request, CancellationToken cancellationToken)
        => mediator.Send(request, cancellationToken);

    [HttpGet("List")]
    public Task<List<TaskViewModel>> GetTasks(CancellationToken cancellationToken)
        => mediator.Send(new GetTasksQuery(), cancellationToken);

    [HttpPut("Status")]
    public Task UpdateTaskStatus(int taskId, CancellationToken cancellationToken)
        => mediator.Send(new UpdateTaskCommand() { TaskId = taskId }, cancellationToken);
    
}