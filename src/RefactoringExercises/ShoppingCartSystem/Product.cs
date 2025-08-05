namespace RefactoringExercises.ShoppingCartSystem;

public record Product(string Name, decimal Price, Category Category)

{
    public decimal CalculateTax(decimal amount) =>
        Category.CalculateTax(amount);
};