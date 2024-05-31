using MediatR;

namespace UserManager.Application.Queries;

public class GetNameQuery : IRequest<string>
{
    public int UserId { get; set; }
}