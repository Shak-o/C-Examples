namespace PatternExamples.Structural.Bridge;

// Client
public class Tv(IRemote remote) : Device(remote)
{
    public override void AddButtonAction()
    {
        base.AddButtonAction();
    }
}