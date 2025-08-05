using RefactoringExercises.ShoppingCartSystem;

namespace RefactoringExercises.Tests.ShoppingCartSystem;

public class CustomerTypeTests
{
    public static IEnumerable<object[]> TestData =
    [
        [CustomerType.Regular, 150.00m, 0.00m],
        [CustomerType.Premium, 200.00m, 20.00m],
        [CustomerType.Vip, 100.00m, 15.00m]
    ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void CanCalculateDiscount(CustomerType sut, decimal amount, decimal expected)
    {
        Assert.Equal(sut.CalculateDiscount(amount), expected);
    }
}