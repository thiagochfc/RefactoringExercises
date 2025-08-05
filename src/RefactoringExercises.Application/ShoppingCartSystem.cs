using RefactoringExercises.ShoppingCartSystem;

namespace RefactoringExercises.Application;

public static class ShoppingCartSystem
{
    public static void Execute()
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

        ShoppingProcessor processor = new();
        (double subtotal, double discount, double tax, double shipping, double total) = 
            processor.ProcessOrder(productNames, productPrices, quantities, categories, customerName, customerType, shippingAddress);
        
        // Display order summary
        Console.WriteLine($"Customer: {customerName} ({customerType})");
        Console.WriteLine($"Shipping Address: {shippingAddress}");
        Console.WriteLine("--- Order Details ---");
        for (int i = 0; i < productNames.Count; i++)
        {
            Console.WriteLine($"{productNames[i]} x{quantities[i]} = ${productPrices[i] * quantities[i]}");
        }
        Console.WriteLine($"Subtotal: ${subtotal}");
        Console.WriteLine($"Discount: -${discount}");
        Console.WriteLine($"Tax: ${tax}");
        Console.WriteLine($"Shipping: ${shipping}");
        Console.WriteLine($"Total: ${total}");
    }
}