namespace RefactoringExercises.ShoppingCartSystem;

public class Product(string name, decimal price, Category category)
{
    public string Name { get; } = name;
    public decimal Price { get; } = price;
    public Category Category { get; } = category;
    
    public decimal CalculateTax(decimal amount) =>
        Category.CalculateTax(amount);
};