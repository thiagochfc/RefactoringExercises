using System.Text;

namespace RefactoringExercises.EmployeeManagement;

public static class EmployeeExtensions
{
    public static string Display(this Employee employee) =>
        $"""
         Employee: {employee.Name}
         Department: {employee.Department.Name}
         Base Salary: {employee.BaseSalary:C}
         Bonus: {employee.Department.Bonus:F2}%
         Total Salary: {employee.Salary:C}
         """;
}