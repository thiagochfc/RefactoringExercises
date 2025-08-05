using RefactoringExercises.ShoppingCartSystem;

namespace RefactoringExercises.Application;

public static class ShoppingCartSystem
{
    public static void Execute()
    {
        // Product data
        List<OrderItem> items =
        [
            new(new Product("Laptop", 999.99m, new Category("Electronics")), 1),
            new(new Product("Mouse", 29.99m, new Category("Electronics")), 2),
            new(new Product("Keyboard", 79.99m, new Category("Electronics")), 1)
        ];

        // Customer data
        Customer customer = new("Alice Smith", "Premium", "123 Main St, City, State");

        ShoppingProcessor processor = new();
        (decimal subtotal, decimal discount, decimal tax, decimal shipping, decimal total) =
            processor.ProcessOrder(items, customer);

        // Display order summary
        Console.WriteLine($"Customer: {customer.Name} ({customer.Type})");
        Console.WriteLine($"Shipping Address: {customer.ShippingAddress}");
        Console.WriteLine("--- Order Details ---");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Product.Name} x{item.Quantity} = ${item.Total}");
        }

        Console.WriteLine($"Subtotal: ${subtotal}");
        Console.WriteLine($"Discount: -${discount}");
        Console.WriteLine($"Tax: ${tax}");
        Console.WriteLine($"Shipping: ${shipping}");
        Console.WriteLine($"Total: ${total}");
    }
}