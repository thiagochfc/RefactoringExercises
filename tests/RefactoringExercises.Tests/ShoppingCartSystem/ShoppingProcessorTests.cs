using RefactoringExercises.ShoppingCartSystem;

namespace RefactoringExercises.Tests.ShoppingCartSystem;

public class ShoppingProcessorTests
{
    [Fact]
    public void CanProcessOrderSuccessfully()
    {
        // Product data
        List<OrderItem> items =
        [
            new(new Product("Laptop", 999.99m, Category.Electronics), 1),
            new(new Product("Mouse", 29.99m, Category.Electronics), 2),
            new(new Product("Keyboard", 79.99m, Category.Electronics), 1)
        ];

        // Customer data
        Customer customer = new("Alice Smith", CustomerType.Premium, "123 Main St, City, State");

        ShoppingProcessor sut = new();
        (decimal subtotal, decimal discount, decimal tax, decimal shipping, decimal total) =
            sut.ProcessOrder(items, customer);

        Assert.Equal(1139.96m, subtotal);
        Assert.Equal(113.9960m, discount);
        Assert.Equal(91.1968m, tax);
        Assert.Equal(9.99m, shipping);
        Assert.Equal(1127.1508m, total);
    }
}