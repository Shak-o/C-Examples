using RestEase;
using TaskManager.Infrastructure.RequestModels;

namespace TaskManager.Infrastructure.ApiClients;

public interface IAuthManagerClient
{
    [Post("/Auth/UsernamePassword")]
    Task<string> AuthenticateByUserNameAndPasswordAsync([Body]AuthenticateUsernamePassRequest request,
        CancellationToken cancellationToken);

    [Post("/Account")]
    Task CreateAccountAsync([Body] CreateAccountRequest request, CancellationToken cancellationToken);
}