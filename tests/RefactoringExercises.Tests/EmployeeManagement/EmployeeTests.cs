using RefactoringExercises.EmployeeManagement;

namespace RefactoringExercises.Tests.EmployeeManagement;

public class EmployeeTests
{
    public static IEnumerable<object[]> TestData =
        [[Department.It, 1150.00m], [Department.Sales, 1200.00m], [Department.Financial, 1100.00m]];
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void CanCalculateSalarySuccessfully(Department department, decimal expected)
    {
        Employee sut = new("John Doe", 1000, 160, department);

        Assert.Equal(expected, sut.Salary);
    }
}