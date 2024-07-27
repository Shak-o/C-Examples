namespace PatternExamples.Structural.Composite;

public class Department : ISomethingToCommandAround, IDepartment
{
    private readonly List<ISomethingToCommandAround> _department = [];
    
    public void DoTask()
    {
        foreach (var item in _department)
        {
            item.DoTask();
        }
    }

    public void ExplainYourself()
    {
        foreach (var item in _department)
        {
            item.ExplainYourself();
        }
    }

    public void AddSomethingToCommandAround(ISomethingToCommandAround somethingToCommandAround)
        => _department.Add(somethingToCommandAround);
    

    public void RemoveSomethingToCommandAround(ISomethingToCommandAround somethingToCommandAround)
        => _department.Remove(somethingToCommandAround);
    

    public List<ISomethingToCommandAround> GetDepartment() => _department;
}