// See https://aka.ms/new-console-template for more information

// Factory examples

using PatternExamples.ConsoleApp.Factory;
using PatternExamples.ConsoleApp.Factory.Creators;

var type = Console.ReadLine();
var creator = type switch
{
    "Developer" => new DeveloperCreator(),
    "Tester" => new TesterCreator(),
    "Analyst" => new AnalystCreator(),
    _ => new EmployeeCreator()
};

var employee = creator.CreateEmployee("test", 23, 1);

Console.WriteLine(employee.CalculateSalary());