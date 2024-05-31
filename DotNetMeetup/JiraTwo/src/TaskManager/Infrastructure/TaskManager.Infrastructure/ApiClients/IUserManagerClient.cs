using RestEase;
using TaskManager.Infrastructure.RequestModels;

namespace TaskManager.Infrastructure.ApiClients;

public interface IUserManagerClient
{
    [Get("/User/Name")]
    Task<string> GetNameAsync([Body]GetNameQuery query, CancellationToken cancellationToken);
}