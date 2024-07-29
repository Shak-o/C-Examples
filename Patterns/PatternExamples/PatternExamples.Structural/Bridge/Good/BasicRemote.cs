namespace PatternExamples.Structural.Bridge.Good;

public class BasicRemote(ITv tv) : RemoteControl(tv)
{
    public override void TurnOn()
    {
        Tv.PowerOn();
    }

    public override void TurnOff()
    {
        Tv.PowerOff();
    }

    public override void ChangeChannel(int channel)
    {
        Tv.SwitchChannel(channel);
    }
}

