using RefactoringExercises.EmployeeManagement;

namespace RefactoringExercises.Tests.EmployeeManagement;

public class EmployeeProcessorTests
{
    [Theory]
    [InlineData("IT", 1150)]
    [InlineData("Sales", 1200)]
    [InlineData("Financial", 1100)]
    public void CanProcessPaymentSuccessfully(string department, double expected)
    {
        Employee employee = new("John Doe", 1000, 160, department);

        var sut = new EmployeeProcessor();
        var result = sut.Process(employee);
        
        Assert.Equal(expected, result);
    }
}