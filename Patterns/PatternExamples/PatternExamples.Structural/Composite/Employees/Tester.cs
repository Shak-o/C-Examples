namespace PatternExamples.Structural.Composite.Employees;

// leaf
public class Tester : ISomethingToCommandAround
{
    public void DoTask()
    {
        Console.WriteLine("Testing Testing Testing...");
    }

    public void ExplainYourself()
    {
        Console.WriteLine("Worked on test environment!");
    }
}