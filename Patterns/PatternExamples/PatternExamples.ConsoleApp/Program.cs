// See https://aka.ms/new-console-template for more information

// Factory examples

using PatternExamples.ConsoleApp.Factory;
using PatternExamples.ConsoleApp.Factory.Creators;

var type = Console.ReadLine();
EmployeeCreator creator;
switch (type)
{
    case "Developer":
        creator = new DeveloperCreator();
        break;
    case "Tester":
        creator = new TesterCreator();
        break;
    case "Analyst":
        creator = new AnalystCreator();
        break;
    default:
        creator = new EmployeeCreator();
        break;
}

var employee = creator.CreateEmployee("test", 23, 1);

Console.WriteLine(employee.CalculateSalary());