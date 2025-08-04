namespace RefactoringExercises.EmployeeManagement;

public class Employee(string name, double baseSalary, int workingHours, string department)
{
    public string Name { get; } = name;
    public double BaseSalary { get; set; } = baseSalary;
    public int WorkingHours { get; set; } = workingHours;
    public string Department { get; set; } = department;
};