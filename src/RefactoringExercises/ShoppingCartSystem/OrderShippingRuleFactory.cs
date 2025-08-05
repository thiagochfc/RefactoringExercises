using RefactoringExercises.ShoppingCartSystem.ShippingRules;

namespace RefactoringExercises.ShoppingCartSystem;

public static class OrderShippingRuleFactory
{
    public static IShippingRule Create()
    {
        DefaultShippingRule defaultShippingRule = new();
        FreeShippingForVipRule freeShippingForVipRule = new(defaultShippingRule);
        LowValueShippingRule lowValueShippingRule = new(freeShippingForVipRule);
        
        // lowValueShippingRule -> freeShippingForVipRule -> defaultShippingRule
        return lowValueShippingRule;
    }
}