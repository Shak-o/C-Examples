using MediatR;
using TaskManager.Application.RepositoryInterfaces;
using TaskManager.Domain.Models;
using TaskManager.Domain.ViewModels;

namespace TaskManager.Application.Queries;

public class GetTasksQueryHandler (ITaskRepository repository) : IRequestHandler<GetTasksQuery, List<TaskViewModel>>
{
    public async Task<List<TaskViewModel>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetTasksAsync();
    }
}