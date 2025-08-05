using RefactoringExercises.ShoppingCartSystem.ShippingRules;

namespace RefactoringExercises.ShoppingCartSystem;

public class Order(Customer customer, List<OrderItem> items, IShippingRule? shippingRule)
{
    public Customer Customer { get; } = customer;
    public IReadOnlyList<OrderItem> Items => items;

    public decimal SubTotal => items.Sum(x => x.Total);
    public decimal Discount => Customer.CalculateDiscount(SubTotal);
    public decimal Tax => items.Sum(x => x.Tax);
    public decimal Shipping => shippingRule?.CalculateShipping(this) ?? 0.00m;
    public decimal Total => (SubTotal + Tax + Shipping) - Discount;
    public bool CustomerVip => Customer.IsVip;
}