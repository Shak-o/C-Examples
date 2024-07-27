namespace PatternExamples.Structural.Composite.Employees;

public class Developer : ISomethingToCommandAround
{
    public void DoTask()
    {
        Console.WriteLine("Developing Developing Developing...");
    }

    public void ExplainYourself()
    {
        Console.WriteLine("Worked on my machine!");
    }
}