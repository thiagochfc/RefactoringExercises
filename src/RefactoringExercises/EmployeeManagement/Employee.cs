using System.Runtime.CompilerServices;

namespace RefactoringExercises.EmployeeManagement;

public class Employee
{
    public string Name { get; }
    public decimal BaseSalary { get; }
    public int WorkingHours { get; }
    public Department Department { get; }
    public decimal Salary => BaseSalary + Department.CalculateBonus(BaseSalary);

    public Employee(string name, decimal baseSalary, int workingHours, Department department)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(baseSalary);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(workingHours);
        ArgumentNullException.ThrowIfNull(department);
    
        Name = name;
        BaseSalary = baseSalary;
        WorkingHours = workingHours;
        Department = department;
    }
};