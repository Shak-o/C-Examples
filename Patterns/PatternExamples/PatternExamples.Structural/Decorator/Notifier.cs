namespace PatternExamples.Structural.Decorator;

public abstract class Notifier
{
    public abstract void Send(string message, string receiver);
}