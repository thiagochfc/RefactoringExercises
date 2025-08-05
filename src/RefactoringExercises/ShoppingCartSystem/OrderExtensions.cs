using System.Text;

namespace RefactoringExercises.ShoppingCartSystem;

public static class OrderExtensions
{
    public static string Display(this Order order)
    {
        StringBuilder sb = new(750);
        string summary =
            $"""
             Customer: {order.Customer.Name} ({order.Customer.Type.Name})
             Shipping Address: {order.Customer.ShippingAddress}
             --- Order Details ---
             """;
        sb.AppendLine(summary);
        foreach (var item in order.Items)
        {
            sb.AppendLine($"{item.Product.Name} x{item.Quantity} = ${item.Total,10:C}");
        }

        string total = $"""
                        Subtotal: {order.SubTotal,10:C}
                        Discount: {-order.Discount,10:C}
                        Tax: {order.Tax,10:C}
                        Shipping: {order.Shipping,10:C}
                        Total: {order.Total,10:C}
                        """;
        sb.AppendLine(total);
        return sb.ToString();
    }
}