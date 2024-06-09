namespace PatternExamples.ConsoleApp.Factory.Products;

public class Tester : BaseEmployee
{
    public int TasksTested { get; set; }
    
    public override decimal CalculateSalary()
    {
        return (Salary * DaysWorked) + TasksTested * (Salary * 2);
    }
}