namespace PatternExamples.Structural.Decorator.Decorators;

public class BaseDecorator(Notifier notifier) : Notifier
{
    public override void Send(string message, string receiver)
    {
        notifier.Send(message, receiver);
    }
}