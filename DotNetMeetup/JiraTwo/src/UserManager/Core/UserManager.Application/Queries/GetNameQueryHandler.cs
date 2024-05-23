using MediatR;
using Presentation.Shared.Exceptions;
using UserManager.Application.RepositoryInterfaces;

namespace UserManager.Application.Queries;

public class GetNameQueryHandler(IUserRepository userRepository) : IRequestHandler<GetNameQuery, string>
{
    public async Task<string> Handle(GetNameQuery request, CancellationToken cancellationToken)
    {
        var name = await userRepository.GetNameAsync(request.UserId, cancellationToken);

        if (name == null)
            throw new ObjectNotFoundException("UserNotFound", "Specified user not found");

        return name;
    }
}