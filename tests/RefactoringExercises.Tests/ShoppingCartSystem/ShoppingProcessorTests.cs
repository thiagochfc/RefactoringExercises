using RefactoringExercises.ShoppingCartSystem;

namespace RefactoringExercises.Tests.ShoppingCartSystem;

public class ShoppingProcessorTests
{
    [Fact]
    public void CanProcessOrderSuccessfully()
    {
        // Product data
        List<string> productNames = ["Laptop", "Mouse", "Keyboard"];
        List<double> productPrices = [999.99, 29.99, 79.99];
        List<int> quantities = [1, 2, 1];
        List<string> categories = ["Electronics", "Electronics", "Electronics"];
        
        // Customer data
        string customerName = "Alice Smith";
        string customerType = "Premium"; // Regular, Premium, VIP
        string shippingAddress = "123 Main St, City, State";
        
        ShoppingProcessor sut = new();
        (double subtotal, double discount, double tax, double shipping, double total) = 
            sut.ProcessOrder(productNames, productPrices, quantities, categories, customerName, customerType, shippingAddress);
        
        Assert.Equal(1139.96, subtotal);
        Assert.Equal(113.99600000000001, discount);
        Assert.Equal(91.1968, tax);
        Assert.Equal(9.99, shipping);
        Assert.Equal(1127.1508, total);
    }
}