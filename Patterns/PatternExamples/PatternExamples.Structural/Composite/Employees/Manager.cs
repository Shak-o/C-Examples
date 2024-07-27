namespace PatternExamples.Structural.Composite.Employees;

public class Manager : ISomethingToCommandAround
{
    public void DoTask()
    {
        Console.WriteLine("Managing Managing Managing...");
    }

    public void ExplainYourself()
    {
        Console.WriteLine("Teams fault!");
    }
}