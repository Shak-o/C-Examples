namespace PatternExamples.Structural.Decorator.Decorators;

public class FacebookNotifier(Notifier notifier) : BaseDecorator(notifier)
{
    public override void Send(string message, string receiver)
    {
        base.Send(message, receiver);
        Console.WriteLine($"Also sent fb message to {receiver}");
    }
}