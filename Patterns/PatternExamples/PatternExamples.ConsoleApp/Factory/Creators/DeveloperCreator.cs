using PatternExamples.ConsoleApp.Factory.Products;

namespace PatternExamples.ConsoleApp.Factory.Creators;

public class DeveloperCreator : EmployeeCreator
{
    public override BaseEmployee CreateEmployee(string name, decimal salary, int daysWorked)
    {
        return new Developer
        {
            Name = name,
            Salary = salary,
            DaysWorked = daysWorked,
            TasksDone = Random.Shared.Next(0, 100)
        };
    }
}