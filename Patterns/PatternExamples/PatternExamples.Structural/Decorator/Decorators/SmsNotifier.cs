namespace PatternExamples.Structural.Decorator.Decorators;

public class SmsNotifier(Notifier notifier) : BaseDecorator(notifier)
{
    public override void Send(string message, string receiver)
    {
        base.Send(message, receiver);
        Console.WriteLine($"Also sent sms to {receiver}");
    }
}