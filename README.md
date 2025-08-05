# Refactoring Exercises - Procedural to OOP

> AI generated these exercises.

## Exercise 1: Basic Employee Management

**Focus**: Basic encapsulation, properties, and single responsibility

**Procedural Code**

```csharp
public class EmployeeProcessor
{
    public static void ProcessEmployee()
    {
        string employeeName = "John Doe";
        double baseSalary = 5000;
        int workingHours = 160;
        string department = "IT";
        
        // Calculate bonus
        double bonus = 0;
        if (department == "IT")
        {
            bonus = baseSalary * 0.15;
        }
        else if (department == "Sales")
        {
            bonus = baseSalary * 0.20;
        }
        else
        {
            bonus = baseSalary * 0.10;
        }
        
        double totalSalary = baseSalary + bonus;
        
        // Display employee info
        Console.WriteLine($"Employee: {employeeName}");
        Console.WriteLine($"Department: {department}");
        Console.WriteLine($"Base Salary: ${baseSalary}");
        Console.WriteLine($"Bonus: ${bonus}");
        Console.WriteLine($"Total Salary: ${totalSalary}");
    }
}
```

[OOP Code](./src/RefactoringExercises/EmployeeManagement/)

### Refactoring Goals

- Create Employee class with proper encapsulation
- Implement different employee types (ITEmployee, SalesEmployee, etc.)
- Apply polymorphism for bonus calculation
- Separate display logic