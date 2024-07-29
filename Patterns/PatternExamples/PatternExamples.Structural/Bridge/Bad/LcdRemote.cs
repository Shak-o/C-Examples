namespace PatternExamples.Structural.Bridge.Bad;

public class LcdRemote
{
    private LcdTv _lcdTv;

    public LcdRemote(LcdTv lcdTv)
    {
        _lcdTv = lcdTv;
    }
    
    public void TurnOn()
    {
        _lcdTv.PowerOn();
    }
    
    public void TurnOff()
    {
        _lcdTv.PowerOff();
    }
    
    public void ChangeChannel(int channel)
    {
        _lcdTv.SwitchChannel(channel);
    }
}
