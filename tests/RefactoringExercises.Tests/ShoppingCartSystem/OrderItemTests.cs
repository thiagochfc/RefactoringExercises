using RefactoringExercises.ShoppingCartSystem;

namespace RefactoringExercises.Tests.ShoppingCartSystem;

public class OrderItemTests
{
    [Fact]
    public void CanCalculateTotal()
    {
        Product product = new("Laptop", 999.99m, new Category("Electronics"));
        OrderItem sut = new(product, 2);
        
        Assert.Equal(1999.98m, sut.Total);
    }
}