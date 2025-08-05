namespace RefactoringExercises.ShoppingCartSystem.ShippingRules;

public sealed record FreeShippingForVipRule(IShippingRule? Next) : IShippingRule
{
    public decimal? CalculateShipping(Order order) =>
        order.CustomerVip
            ? 0.00m
            : Next?.CalculateShipping(order);
}