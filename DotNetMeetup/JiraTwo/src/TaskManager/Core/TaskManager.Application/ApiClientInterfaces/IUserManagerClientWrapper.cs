namespace TaskManager.Application.ApiClientInterfaces;

public interface IUserManagerClientWrapper
{
    Task<string> GetNameAsync(int id, CancellationToken cancellationToken);
}