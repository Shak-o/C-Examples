namespace UserManager.Application.RepositoryInterfaces;

public interface IAuthSessionRepository
{
    Task<int> InitializeSessionAsync(int accountId);
}