namespace RefactoringExercises.ShoppingCartSystem;

public class ShoppingProcessor
{
    public (decimal, decimal, decimal, decimal, decimal) ProcessOrder(List<OrderItem> items, Customer customer)
    {
        // Calculate subtotal
        decimal subtotal = 0;
        foreach (var item in items)
        {
            subtotal += item.Total;
        }
        
        // Apply discount based on customer type
        decimal discount = 0;
        if (customer.Type == "Premium")
        {
            discount = subtotal * 0.10m;
        }
        else if (customer.Type == "VIP")
        {
            discount = subtotal * 0.15m;
        }
        
        // Calculate tax (different rates for different categories)
        decimal tax = 0;
        foreach (var item in items)
        {
            decimal itemTotal = item.Total;
            if (item.Product.Category.Name == "Electronics")
            {
                tax += itemTotal * 0.08m;
            }
            else if (item.Product.Category.Name == "Books")
            {
                tax += itemTotal * 0.05m;
            }
            else
            {
                tax += itemTotal * 0.07m;
            }
        }
        
        // Calculate shipping
        decimal shipping = 0;
        if (subtotal < 100)
        {
            shipping = 15.99m;
        }
        else if (customer.Type == "VIP")
        {
            shipping = 0; // Free shipping for VIP
        }
        else
        {
            shipping = 9.99m;
        }
        
        decimal total = subtotal - discount + tax + shipping;
        return (subtotal, discount, tax, shipping, total);
    }
}