namespace PatternExamples.Structural.Composite.Employees;

public class SomeoneInBetween : ISomethingToCommandAround
{
    public void DoTask()
    {
        Console.WriteLine("SomeoneInBetween: God knows what this guy is doin");
    }

    public void ExplainYourself()
    {
        Console.WriteLine("SomeoneInBetween: Im just a small man, I do whatever Im told to");
    }
}