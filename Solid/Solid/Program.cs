using Solid.SRP;

var employee = new Employee();
var service = new EmployeeService();
var emailService = new EmailService();

service.AddEmployee(employee);
Console.WriteLine(EmployeeData.Employees.Count);
emailService.SendMail("message", "tome");
Console.WriteLine("random change");