namespace RefactoringExercises.ShoppingCartSystem;

public record CustomerType : IDiscountable
{
    public static readonly CustomerType Regular = new("Regular");
    public static readonly CustomerType Premium = new("Premium");
    public static readonly CustomerType Vip = new("VIP");

    public string Name { get; }

    private CustomerType(string name) => 
        Name = name;

    public decimal CalculateDiscount(decimal amount) => Name switch
    {
        "Premium" => Decimal.Round(amount * 0.10m, 2),
        "VIP" => Decimal.Round(amount * 0.15m, 2),
        _ => 0.00m
    };
    
    public override string ToString() => 
        Name;
}