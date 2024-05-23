namespace UserManager.Domain.Models;

public class Account : BaseModel
{
    public required string Username { get; set; }
    public required byte[] Salt { get; set; }
    public required string PasswordHash { get; set; }
    public DateTime ValidTill { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public AccountStatus Status { get; set; }
    public AccountType AccountType { get; set; }
}

public enum AccountStatus
{
    Active,
    TempBlocked,
    Blocked
}

public enum AccountType
{
    Normal,
    Admin
}