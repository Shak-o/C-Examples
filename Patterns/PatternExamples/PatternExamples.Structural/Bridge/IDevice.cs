namespace PatternExamples.Structural.Bridge;

public interface IDevice
{
    void TurnOn();
    void TurnOff();
    void SetVolume(int amount);
}