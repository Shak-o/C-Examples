namespace PatternExamples.Structural.Bridge;

public class Remote : IRemote
{
    private int _currentAmount = 0;
    public void AddVolume(int amount)
    {
        _currentAmount += amount;
    }
}