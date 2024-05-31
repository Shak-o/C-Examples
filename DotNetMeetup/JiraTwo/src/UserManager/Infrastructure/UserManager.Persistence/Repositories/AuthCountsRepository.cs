using Microsoft.EntityFrameworkCore;
using UserManager.Application.RepositoryInterfaces;
using UserManager.Domain.Models;

namespace UserManager.Persistence.Repositories;

public class AuthCountsRepository(UserManagerContext dbContext) : IAuthCountsRepository
{
    private static readonly int MaxAttempts = 3; // Temporarily Hardcoded
    public async Task<AuthCountStatus> UpsertCountAsync(int accountId, int sessionId, CancellationToken cancellationToken)
    {
        var existing = await dbContext.AuthCounts.FirstOrDefaultAsync(x => x.AccountId == accountId && x.AuthSessionId == sessionId,
            cancellationToken);

        if (existing != null)
        {
            if (existing.Count >= MaxAttempts)
                return AuthCountStatus.Failed;

            existing.Count++;

            await dbContext.SaveChangesAsync(cancellationToken);
            return AuthCountStatus.CanRetry;
        }

        var count = new AuthCount
        {
            AccountId = accountId,
            AuthSessionId = sessionId,
            Count = 1
        };

        dbContext.AuthCounts.Add(count);
        await dbContext.SaveChangesAsync(cancellationToken);

        return AuthCountStatus.CanRetry;
    }
}