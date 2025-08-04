namespace RefactoringExercises.EmployeeManagement;

public class EmployeeProcessor
{
    public double Process(Employee employee)
    {
        // Calculate bonus
        double bonus = 0;
        if (employee.Department == "IT")
        {
            bonus = employee.BaseSalary * 0.15;
        }
        else if (employee.Department == "Sales")
        {
            bonus = employee.BaseSalary * 0.20;
        }
        else
        {
            bonus = employee.BaseSalary * 0.10;
        }

        return employee.BaseSalary + bonus;
    }
}