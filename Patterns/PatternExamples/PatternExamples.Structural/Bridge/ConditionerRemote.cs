namespace PatternExamples.Structural.Bridge;

public class ConditionerRemote : IRemote
{
    private int _fanSpeed;
    public void AddVolume(int amount)
    {
        _fanSpeed += amount;
        Console.WriteLine($"Fan speed set to: {_fanSpeed}");
    }
}