namespace PatternExamples.ConsoleApp.Factory.Products;

public class Analyst : BaseEmployee
{
    public int TasksAnalyzed { get; set; }
    
    public override decimal CalculateSalary()
    {
        return (Salary * DaysWorked) + TasksAnalyzed * (Salary * 2);
    }
}