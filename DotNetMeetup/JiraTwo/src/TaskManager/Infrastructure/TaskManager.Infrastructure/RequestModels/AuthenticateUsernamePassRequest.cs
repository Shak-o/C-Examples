namespace TaskManager.Infrastructure.RequestModels;

public class AuthenticateUsernamePassRequest
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public AccountType AccountType { get; set; }
}

public enum AccountType
{
    Normal,
    Admin
}