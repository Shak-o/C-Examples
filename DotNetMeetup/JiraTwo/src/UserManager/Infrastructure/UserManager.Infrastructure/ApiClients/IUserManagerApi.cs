using RestEase;
using UserManager.Application.Commands.AuthCommands;
using UserManager.Application.ViewModels;

namespace UserManager.Infrastructure.ApiClients;

public interface IUserManagerApi
{
    [Post("/Auth/UsernamePassword")]
    Task<string> AuthenticateByUserNameAndPasswordAsync([Body]AuthenticateUsernamePassRequest request,
        CancellationToken cancellationToken);
    
    [Get("/Account/{page}")]
    Task<List<UserViewModel>> GetUserListAsync([Path]int page, CancellationToken cancellationToken);

    [Put("/Account/{accountId}/status")]
    Task<bool> UpdateStatusAsync([Path] int accountId, CancellationToken cancellationToken);
}