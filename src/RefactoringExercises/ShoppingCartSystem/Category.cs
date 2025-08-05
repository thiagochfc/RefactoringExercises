namespace RefactoringExercises.ShoppingCartSystem;

public record Category : ITaxable
{
    public static readonly Category Electronics = new("Electronics");
    public static readonly Category Books = new("Books");
    public static readonly Category General = new("General");

    public string Name { get; }

    private Category(string name) => 
        Name = name;

    public decimal CalculateTax(decimal amount) => Name switch
    {
        "Electronics" => Decimal.Round(amount * 0.08m, 2),
        "Books" => Decimal.Round(amount * 0.05m, 2),
        _ => Decimal.Round(amount * 0.07m, 2)
    };

    public override string ToString() => 
        Name;
};