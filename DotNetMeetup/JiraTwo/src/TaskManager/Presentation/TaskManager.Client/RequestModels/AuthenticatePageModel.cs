using TaskManager.Infrastructure.RequestModels;

namespace TaskManager.Client.RequestModels;

public class AuthenticatePageModel
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public AccountType AccountType { get; set; }
}
