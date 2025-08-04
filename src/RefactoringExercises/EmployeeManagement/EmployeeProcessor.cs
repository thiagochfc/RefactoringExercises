namespace RefactoringExercises.EmployeeManagement;

public class EmployeeProcessor
{
    public double Process(double baseSalary, string department)
    {
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

        return baseSalary + bonus;
    }
}