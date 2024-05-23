namespace UserManager.Application.RepositoryInterfaces;

public interface IUserRepository
{
    Task<string?> GetNameAsync(int id, CancellationToken cancellationToken);
}