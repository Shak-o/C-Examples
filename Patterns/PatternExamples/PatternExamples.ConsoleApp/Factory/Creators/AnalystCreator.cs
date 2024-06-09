using PatternExamples.ConsoleApp.Factory.Products;

namespace PatternExamples.ConsoleApp.Factory.Creators;

public class AnalystCreator : EmployeeCreator
{
    public override BaseEmployee CreateEmployee(string name, decimal salary, int daysWorked)
    {
        return new Analyst
        {
            Name = name,
            Salary = salary,
            DaysWorked = daysWorked,
            TasksAnalyzed = Random.Shared.Next(0, 100)
        };
    }
}