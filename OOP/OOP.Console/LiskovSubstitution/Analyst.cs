namespace OOP.Console.LiskovSubstitution;

public class Analyst : Employee
{
    public override void DoWork()
    {
        System.Console.WriteLine("Analyst is working");
    }
}