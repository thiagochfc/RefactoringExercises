namespace RefactoringExercises.ShoppingCartSystem;

public interface ITaxable
{
    decimal CalculateTax(decimal amount);
}