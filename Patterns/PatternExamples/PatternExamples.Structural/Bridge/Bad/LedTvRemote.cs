namespace PatternExamples.Structural.Bridge.Bad;

public class LedTvRemote
{
    private readonly LedTv _ledTv;

    public LedTvRemote(LedTv ledTv)
    {
        _ledTv = ledTv;
    }
    
    public void TurnOn()
    {
        _ledTv.PowerOn();
    }
    
    public void TurnOff()
    {
        _ledTv.PowerOff();
    }
    
    public void ChangeChannel(int channel)
    {
        _ledTv.SwitchChannel(channel);
    }
}
