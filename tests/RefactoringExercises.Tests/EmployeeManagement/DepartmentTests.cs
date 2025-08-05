using RefactoringExercises.EmployeeManagement;

namespace RefactoringExercises.Tests.EmployeeManagement;

public class DepartmentTests
{
    public static IEnumerable<object[]> TestData =
        [[Department.It, 150.00m], [Department.Sales, 200.00m], [Department.Financial, 100.00m]];

    [Theory]
    [MemberData(nameof(TestData))]
    public void CanCalculateBonus(Department sut, decimal expected)
    {
        Assert.Equal(expected, sut.CalculateBonus(1000));
    }
}