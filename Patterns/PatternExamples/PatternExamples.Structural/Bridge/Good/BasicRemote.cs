namespace PatternExamples.Structural.Bridge.Good;

public class BasicRemote: RemoteControl
{
    private readonly ITv _tv;

    public BasicRemote(ITv tv) : base(tv)
    {
        _tv = tv;
    }

    public override void TurnOn()
    {
        _tv.PowerOn();
    }

    public override void TurnOff()
    {
        _tv.PowerOff();
    }

    public override void ChangeChannel(int channel)
    {
        _tv.SwitchChannel(channel);
    }
}

