// See https://aka.ms/new-console-template for more information

using RefactoringExercises.EmployeeManagement;

string employeeName = "John Doe";
double baseSalary = 5000;
int workingHours = 160;
string department = "IT";

var processor = new EmployeeProcessor();
var totalSalary = processor.Process(baseSalary, department);

Console.WriteLine($"Employee: {employeeName}");
Console.WriteLine($"Department: {department}");
Console.WriteLine($"Base Salary: ${baseSalary}");
Console.WriteLine($"Total Salary: ${totalSalary}");