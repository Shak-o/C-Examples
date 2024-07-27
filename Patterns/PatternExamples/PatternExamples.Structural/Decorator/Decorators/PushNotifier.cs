namespace PatternExamples.Structural.Decorator.Decorators;

public class PushNotifier(Notifier notifier) : BaseDecorator(notifier)
{
    public override void Send(string message, string receiver)
    {
        base.Send(message, receiver);
        Console.WriteLine($"also sent push notification to {receiver}");
    }
}