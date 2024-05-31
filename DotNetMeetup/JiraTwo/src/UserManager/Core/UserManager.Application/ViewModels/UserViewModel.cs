using UserManager.Domain.Models;

namespace UserManager.Application.ViewModels;

public class UserViewModel
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string? Email { get; set; }
    public DateTime ValidTill { get; set; }
    public int UserId { get; set; }
    public int AccountId { get; set; }
    public AccountStatus Status { get; set; }
    public AccountType AccountType { get; set; }
}