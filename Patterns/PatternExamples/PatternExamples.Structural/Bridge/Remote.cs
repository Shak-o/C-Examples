namespace PatternExamples.Structural.Bridge;

public class Remote(IDevice device)
{
    private bool _isOn;

    public virtual void Power()
    {
        if (_isOn)
        {
            device.TurnOff();
            _isOn = false;
        }
        else
        {
            device.TurnOn();
            _isOn = true;
        }
    }
}
