namespace OOP.Console.LiskovSubstitution;

public abstract class Employee
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public decimal Salary { get; set; }

    public abstract void DoWork();
}