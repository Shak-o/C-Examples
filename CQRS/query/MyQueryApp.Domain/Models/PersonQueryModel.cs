namespace MyQueryApp.Domain.Models;

public class PersonQueryModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string SurName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public List<UserQueryModel> Users { get; set; } = null!;
}