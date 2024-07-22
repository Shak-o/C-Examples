namespace PatternExamples.Structural.Bridge;

public class Conditioner (IRemote remote) : Device(remote)
{
    public override void AddButtonAction()
    {
        remote.AddVolume(2);
    }
}