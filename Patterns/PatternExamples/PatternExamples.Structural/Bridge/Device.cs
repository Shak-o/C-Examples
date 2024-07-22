namespace PatternExamples.Structural.Bridge;

public class Device (IRemote remote)
{
    public virtual void AddButtonAction()
    {
        remote.AddVolume(1);
    }
}