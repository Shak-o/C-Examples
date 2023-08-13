namespace MyApplication.Domain.Models;

public class User
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Salt { get; set; } = null!;
}