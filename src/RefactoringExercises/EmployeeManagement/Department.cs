namespace RefactoringExercises.EmployeeManagement;

public record Department
{
    public static readonly Department It = new("IT", 15.00m);
    public static readonly Department Sales = new("Sales", 20.00m);
    public static readonly Department Financial = new("Financial", 10.00m);

    public string Name { get; }
    public decimal Bonus { get; }
    private readonly decimal _bonusPercentage;

    private Department(string name, decimal bonus)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentOutOfRangeException.ThrowIfLessThan(bonus, 1);
        Name = name;
        Bonus = bonus;
        _bonusPercentage = bonus / 100.00m;
    }

    public decimal CalculateBonus(decimal salary) =>
        salary * _bonusPercentage;
}