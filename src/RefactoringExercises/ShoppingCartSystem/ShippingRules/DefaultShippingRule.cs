namespace RefactoringExercises.ShoppingCartSystem.ShippingRules;

public sealed record DefaultShippingRule : IShippingRule
{
    public IShippingRule? Next => null;

    public decimal? CalculateShipping(Order order) =>
        9.99m;
}