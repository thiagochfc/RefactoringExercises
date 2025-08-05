using RefactoringExercises.EmployeeManagement;

namespace RefactoringExercises.Application;

public static class EmployeeManagement
{
    public static void Execute()
    {
        Employee employee = new("John Doe", 5000, 160, Department.It);
        Console.WriteLine(employee.Display());
    }
}