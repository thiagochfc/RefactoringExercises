namespace RefactoringExercises.ShoppingCartSystem.ShippingRules;

public sealed record LowValueShippingRule(IShippingRule? Next) : IShippingRule
{
    public decimal? CalculateShipping(Order order) =>
        order.SubTotal < 100.00m 
            ? 15.99m 
            : Next?.CalculateShipping(order);
}