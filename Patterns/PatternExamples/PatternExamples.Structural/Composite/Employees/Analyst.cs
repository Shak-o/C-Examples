namespace PatternExamples.Structural.Composite.Employees;

public class Analyst : ISomethingToCommandAround
{
    public void DoTask()
    {
        Console.WriteLine("Analyzing Analyzing Analyzing...");
    }

    public void ExplainYourself()
    {
        Console.WriteLine("Managements fault!");
    }
}