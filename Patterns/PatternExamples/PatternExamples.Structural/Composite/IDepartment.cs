namespace PatternExamples.Structural.Composite;

public interface IDepartment
{
    void AddSomethingToCommandAround(ISomethingToCommandAround somethingToCommandAround);
    void RemoveSomethingToCommandAround(ISomethingToCommandAround somethingToCommandAround);
    List<ISomethingToCommandAround> GetDepartment();
}