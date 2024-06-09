using PatternExamples.ConsoleApp.Factory.Products;

namespace PatternExamples.ConsoleApp.Factory.Creators;

public class TesterCreator : EmployeeCreator
{
    public override BaseEmployee CreateEmployee(string name, decimal salary, int daysWorked)
    {
        return new Tester
        {
            Name = name,
            Salary = salary,
            DaysWorked = daysWorked,
            TasksTested = Random.Shared.Next(0, 100)
        };
    }
}