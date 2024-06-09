namespace PatternExamples.ConsoleApp.Factory;

public class EmployeeCreator
{
    public virtual BaseEmployee CreateEmployee(string name, decimal salary, int daysWorked)
    {
        return new BaseEmployee
        {
            Name = name,
            Salary = salary,
            DaysWorked = daysWorked
        };
    }
}