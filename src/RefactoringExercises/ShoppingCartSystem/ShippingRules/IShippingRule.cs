namespace RefactoringExercises.ShoppingCartSystem.ShippingRules;

public interface IShippingRule
{
    IShippingRule? Next { get; }
    decimal? CalculateShipping(Order order);
}