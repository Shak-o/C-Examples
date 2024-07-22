namespace PatternExamples.Structural.Bridge;

public class TvRemote : IRemote
{
    private int _volume;

    public void AddVolume(int amount)
    {
        _volume += amount;
        Console.WriteLine($"TV volume set to: {_volume}");
    }
}