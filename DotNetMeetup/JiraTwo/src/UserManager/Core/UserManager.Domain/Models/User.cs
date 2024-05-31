namespace UserManager.Domain.Models;

public class User : BaseModel
{
    public required string Name { get; set; }
    public string? Email { get; set; }
    public required string SurName { get; set; }
    public UserStatus Status { get; set; }
}

public enum UserStatus
{
    Active,
    Suspended,
    Deleted
}