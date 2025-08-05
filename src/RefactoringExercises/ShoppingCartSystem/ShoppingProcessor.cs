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

        // Apply discount based on customer
        decimal discount = customer.CalculateDiscount(subtotal);

        // Calculate tax
        decimal tax = 0;
        foreach (var item in items)
        {
            tax += item.Tax;
        }

        // Calculate shipping
        decimal shipping = 0;
        if (subtotal < 100)
        {
            shipping = 15.99m;
        }
        else if (customer.Type.Name == "VIP")
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