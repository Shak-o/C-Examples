namespace PatternExamples.Structural.Bridge;

public class ConditionerRemote(IDevice device) : Remote(device)
{
    private int _currentFanSpeed = 0;
    
    public void IncreaseFanSpeed()
    {
        _currentFanSpeed += 5;
        device.SetVolume(5);
    }
}
