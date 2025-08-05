using RefactoringExercises.ShoppingCartSystem;

namespace RefactoringExercises.Tests.ShoppingCartSystem;

public class CategoryTests
{
    public static IEnumerable<object[]> TestData =
    [
        [Category.Electronics, 150.00m, 12.00m],
        [Category.Books, 200.00m, 10.00m],
        [Category.General, 100.00m, 7.00m]
    ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void CanCalculateTax(Category sut, decimal amount, decimal expected)
    {
        Assert.Equal(sut.CalculateTax(amount), expected);
    }
}