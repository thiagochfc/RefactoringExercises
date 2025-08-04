// See https://aka.ms/new-console-template for more information

using RefactoringExercises.EmployeeManagement;

Employee employee = new("John Doe", 5000, 160, "IT");

var processor = new EmployeeProcessor();
var totalSalary = processor.Process(employee);

Console.WriteLine($"Employee: {employee.Name}");
Console.WriteLine($"Department: {employee.Department}");
Console.WriteLine($"Base Salary: ${employee.BaseSalary}");
Console.WriteLine($"Total Salary: ${totalSalary}");