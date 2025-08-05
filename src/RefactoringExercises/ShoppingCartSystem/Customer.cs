namespace RefactoringExercises.ShoppingCartSystem;

public record Customer(string Name, CustomerType Type, string ShippingAddress)
{
    public decimal CalculateDiscount(decimal amount) => 
        Type.CalculateDiscount(amount);
};