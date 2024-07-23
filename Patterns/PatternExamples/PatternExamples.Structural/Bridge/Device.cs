namespace PatternExamples.Structural.Bridge;

public class Device : IDevice
{
    private int _volume = 0;
    public void TurnOn()
    {
        Console.WriteLine("On");
    }

    public void TurnOff()
    {
        Console.WriteLine("Off");
    }

    public void SetVolume(int amount)
    {
        _volume = amount;
    }
}
