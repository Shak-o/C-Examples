using Microsoft.EntityFrameworkCore;
using UserManager.Application.RepositoryInterfaces;

namespace UserManager.Persistence.Repositories;

public class UserRepository(UserManagerContext context) : IUserRepository
{
    public async Task<string?> GetNameAsync(int id, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (user == null)
            return null;

        return $"{user.Name} {user.SurName}";
    }
}