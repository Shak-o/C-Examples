using UserManager.Application.RepositoryInterfaces;
using UserManager.Domain.Models;

namespace UserManager.Persistence.Repositories;

public class AuthSessionRepository(UserManagerContext userManagerContext) : IAuthSessionRepository
{
    public async Task<int> InitializeSessionAsync(int accountId)
    {
        var session = new AuthSession
        {
            AccountId = accountId,
            CreateDate = DateTime.Now,
            Status = AuthSessionStatus.Active
        };

        userManagerContext.AuthSessions.Add(session);
        await userManagerContext.SaveChangesAsync();
        
        return session.Id;
    }
}