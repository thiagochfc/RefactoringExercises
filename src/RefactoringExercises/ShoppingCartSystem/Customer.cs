using System.Diagnostics.CodeAnalysis;

namespace RefactoringExercises.ShoppingCartSystem;

public record Customer(string Name, CustomerType Type, string ShippingAddress)
{
    public bool IsVip => Type.Name == "VIP";

    public decimal CalculateDiscount(decimal amount) =>
        Type.CalculateDiscount(amount);
};