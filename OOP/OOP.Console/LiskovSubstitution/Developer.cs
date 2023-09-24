namespace OOP.Console.LiskovSubstitution;

public class Developer : Employee
{
    public override void DoWork()
    {
        System.Console.WriteLine("Developer is working, do not disturb em");
    }
}