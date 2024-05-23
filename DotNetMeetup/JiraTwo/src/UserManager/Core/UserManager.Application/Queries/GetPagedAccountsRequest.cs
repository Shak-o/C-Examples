using MediatR;
using UserManager.Application.ViewModels;

namespace UserManager.Application.Queries;

public class GetPagedAccountsRequest : IRequest<List<UserViewModel>>
{
    public int Page { get; set; }
}