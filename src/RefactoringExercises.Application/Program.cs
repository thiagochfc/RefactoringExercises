// See https://aka.ms/new-console-template for more information

using RefactoringExercises.EmployeeManagement;

Employee employee = new("John Doe", 5000, 160, Department.It);
Console.WriteLine(employee.Display());