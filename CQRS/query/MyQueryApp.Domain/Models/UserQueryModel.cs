namespace MyQueryApp.Domain.Models;

public class UserQueryModel
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Salt { get; set; } = null!;
}