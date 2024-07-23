namespace PatternExamples.Structural.Bridge;

public class TvRemote(IDevice device) : Remote(device)
{
    public void Mute()
    {
        device.SetVolume(0);
    }
}
