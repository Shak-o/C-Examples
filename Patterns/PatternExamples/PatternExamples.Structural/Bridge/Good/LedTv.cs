namespace PatternExamples.Structural.Bridge.Good;

public class LedTv : ITv
{
    public void PowerOn()
    {
        Console.WriteLine("LedTv is powered on");
    }

    public void PowerOff()
    {
        Console.WriteLine("LedTv is powered off");
    }

    public void SwitchChannel(int channel)
    {
        Console.WriteLine($"LedTv: Switched to channel {channel}");
    }
}
