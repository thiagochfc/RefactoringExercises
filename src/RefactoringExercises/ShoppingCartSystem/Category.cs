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
        "Electronics" => amount * 0.08m,
        "Books" => amount * 0.05m,
        _ => amount * 0.07m
    };

    public override string ToString() => 
        Name;
};