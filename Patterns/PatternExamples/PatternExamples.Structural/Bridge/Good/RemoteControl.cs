namespace PatternExamples.Structural.Bridge.Good;

public abstract class RemoteControl
{
    protected ITv Tv;
    public RemoteControl(ITv tv) {
        tv = Tv;
    }
    public abstract void TurnOn();
    public abstract void TurnOff();
    public abstract void ChangeChannel(int channel);
}
