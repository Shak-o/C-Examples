namespace PatternExamples.ConsoleApp.Factory;

public class BaseEmployee
{
    public required string Name { get; set; }
    public decimal Salary { get; set; }
    public int DaysWorked { get; set; }

    public virtual decimal CalculateSalary()
    {
        return Salary * DaysWorked;
    }
}