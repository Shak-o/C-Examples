namespace MyApplication.Domain.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string SurName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
}