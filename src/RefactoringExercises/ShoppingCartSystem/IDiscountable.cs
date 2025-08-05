namespace RefactoringExercises.ShoppingCartSystem;

public interface IDiscountable
{
    decimal CalculateDiscount(decimal amount);
}