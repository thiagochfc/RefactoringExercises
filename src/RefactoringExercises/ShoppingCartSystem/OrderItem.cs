namespace RefactoringExercises.ShoppingCartSystem;

public record OrderItem(Product Product, int Quantity)
{
    public decimal Total => Product.Price * Quantity;
    public decimal Tax => Product.CalculateTax(Total);
}