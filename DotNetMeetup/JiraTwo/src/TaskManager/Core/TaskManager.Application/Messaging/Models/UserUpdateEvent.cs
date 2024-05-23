namespace TaskManager.Application.Messaging.Models;

public class UserUpdateEvent
{
    public int UserId { get; set; }
    public AccountStatus AccountStatus { get; set; }
    public UserStatus UserStatus { get; set; }
}
public enum AccountStatus
{
    Active,
    TempBlocked,
    Blocked
}
public enum UserStatus
{
    Active,
    Suspended,
    Deleted
}