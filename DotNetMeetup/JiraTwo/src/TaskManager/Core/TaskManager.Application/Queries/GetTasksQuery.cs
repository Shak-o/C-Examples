using MediatR;
using TaskManager.Domain.Models;
using TaskManager.Domain.ViewModels;

namespace TaskManager.Application.Queries;

public class GetTasksQuery : IRequest<List<TaskViewModel>> 
{
    
}