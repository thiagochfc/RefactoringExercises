namespace RefactoringExercises.ShoppingCartSystem;

public class ShoppingProcessor
{
    public (double, double, double, double, double) ProcessOrder(List<string> productNames, List<double> productPrices, List<int> quantities,
        List<string> categories, string customerName, string customerType, string shippingAddress)
    {
        // Calculate subtotal
        double subtotal = 0;
        for (int i = 0; i < productNames.Count; i++)
        {
            subtotal += productPrices[i] * quantities[i];
        }
        
        // Apply discount based on customer type
        double discount = 0;
        if (customerType == "Premium")
        {
            discount = subtotal * 0.10;
        }
        else if (customerType == "VIP")
        {
            discount = subtotal * 0.15;
        }
        
        // Calculate tax (different rates for different categories)
        double tax = 0;
        for (int i = 0; i < categories.Count; i++)
        {
            double itemTotal = productPrices[i] * quantities[i];
            if (categories[i] == "Electronics")
            {
                tax += itemTotal * 0.08;
            }
            else if (categories[i] == "Books")
            {
                tax += itemTotal * 0.05;
            }
            else
            {
                tax += itemTotal * 0.07;
            }
        }
        
        // Calculate shipping
        double shipping = 0;
        if (subtotal < 100)
        {
            shipping = 15.99;
        }
        else if (customerType == "VIP")
        {
            shipping = 0; // Free shipping for VIP
        }
        else
        {
            shipping = 9.99;
        }
        
        double total = subtotal - discount + tax + shipping;
        return (subtotal, discount, tax, shipping, total);
    }
}