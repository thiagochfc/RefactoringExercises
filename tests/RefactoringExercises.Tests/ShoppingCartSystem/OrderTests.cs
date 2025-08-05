using RefactoringExercises.ShoppingCartSystem;

namespace RefactoringExercises.Tests.ShoppingCartSystem;

public class OrderTests
{
    public OrderTests()
    {
        
    }
    
    [Fact]
    public void CanCreateOrderSuccessfully()
    {
        // Customer data
        Customer customer = new("Alice Smith", CustomerType.Premium, "123 Main St, City, State");
        
        // Product data
        List<OrderItem> items =
        [
            new(new Product("Laptop", 999.99m, Category.Electronics), 1),
            new(new Product("Mouse", 29.99m, Category.Electronics), 2),
            new(new Product("Keyboard", 79.99m, Category.Electronics), 1)
        ];
        
        // Order Data
        Order sut = new(customer, items, OrderShippingRuleFactory.Create());

        Assert.Equal(1139.96m, sut.SubTotal);
        Assert.Equal(114.00m, sut.Discount);
        Assert.Equal(91.20m, sut.Tax);
        Assert.Equal(9.99m, sut.Shipping);
        Assert.Equal(1127.15m, sut.Total);
    }
}