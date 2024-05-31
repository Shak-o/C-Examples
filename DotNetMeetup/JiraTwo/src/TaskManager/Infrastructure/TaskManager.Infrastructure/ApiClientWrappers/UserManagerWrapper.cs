using TaskManager.Application.ApiClientInterfaces;
using TaskManager.Infrastructure.ApiClients;
using TaskManager.Infrastructure.RequestModels;

namespace TaskManager.Infrastructure.ApiClientWrappers;

public class UserManagerWrapper(IUserManagerClient apiClient) : IUserManagerClientWrapper
{
    public Task<string> GetNameAsync(int id, CancellationToken cancellationToken)
    {
        return apiClient.GetNameAsync(new GetNameQuery() { UserId = id }, cancellationToken);
    }
}