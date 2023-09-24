namespace OOP.Console.LiskovSubstitution;

/// <summary>
/// The Liskov substitution principle states that if a method uses a base class, then it should be able to use any of
/// its derived classes without the need of having the information about the derived class.
/// In other words, the derived classes should be substitutable for their base class without causing errors or side effects.
/// This means that the behavior of the derived class should not contradict the behavior of the base class.
/// </summary>
public class Company
{
    /// <summary>
    /// In this employee list I might have analysts, developers or any other type of employees. Despite that I am working
    /// with them without any change.
    /// </summary>
    public List<Employee> Employees { get; set; } = null!;

    public void StartWorking()
    {
        foreach (var employee in Employees)
        {
            employee.DoWork();
        }
    }
}