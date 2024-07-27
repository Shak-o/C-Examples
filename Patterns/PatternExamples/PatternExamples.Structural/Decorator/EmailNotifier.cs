namespace PatternExamples.Structural.Decorator;

public class EmailNotifier : Notifier //Default
{
    public override void Send(string message, string receiver)
    {
        Console.WriteLine($"Sent Email to: {receiver}");
    }
}