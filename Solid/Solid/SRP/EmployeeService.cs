namespace Solid.SRP
{
    public class EmployeeService
    {
        public void AddEmployee(Employee employee)
        {
            EmployeeData.Employees.Add(employee);
        }
    }
}
