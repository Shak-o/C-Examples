using UserManager.Domain.Models;

namespace UserManager.Application.RepositoryInterfaces;

public interface IAuthCountsRepository
{
    public Task<AuthCountStatus> UpsertCountAsync(int accountId, int sessionId, CancellationToken cancellationToken);
}