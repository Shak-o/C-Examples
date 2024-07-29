namespace PatternExamples.Structural.Bridge.Bad;

public class LcdTv
{
    public void PowerOn()
    {
        Console.WriteLine("LcdTv is powered on");
    }

    public void PowerOff()
    {
        Console.WriteLine("LcdTv is powered off");
    }

    public void SwitchChannel(int channel)
    {
        Console.WriteLine($"LcdTv: Switched to channel {channel}");
    }
}
