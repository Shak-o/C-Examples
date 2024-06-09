namespace PatternExamples.ConsoleApp.Factory.Products;

public class Developer : BaseEmployee
{
    public int TasksDone { get; set;}
    
    public override decimal CalculateSalary()
    {
        return (Salary * DaysWorked) + TasksDone * (Salary * 2);
    }
}