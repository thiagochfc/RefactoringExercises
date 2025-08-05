# Refactoring Exercises - Procedural to OOP

> AI generated these exercises.

## Exercise 1: Basic Employee Management

**Focus**: Basic encapsulation, properties, and single responsibility

**Procedural Code**

```csharp
public class EmployeeProcessor
{
    public static void ProcessEmployee()
    {
        string employeeName = "John Doe";
        double baseSalary = 5000;
        int workingHours = 160;
        string department = "IT";
        
        // Calculate bonus
        double bonus = 0;
        if (department == "IT")
        {
            bonus = baseSalary * 0.15;
        }
        else if (department == "Sales")
        {
            bonus = baseSalary * 0.20;
        }
        else
        {
            bonus = baseSalary * 0.10;
        }
        
        double totalSalary = baseSalary + bonus;
        
        // Display employee info
        Console.WriteLine($"Employee: {employeeName}");
        Console.WriteLine($"Department: {department}");
        Console.WriteLine($"Base Salary: ${baseSalary}");
        Console.WriteLine($"Bonus: ${bonus}");
        Console.WriteLine($"Total Salary: ${totalSalary}");
    }
}
```

[OOP Code](./src/RefactoringExercises/EmployeeManagement/)

### Refactoring Goals

- Create Employee class with proper encapsulation
- Implement different employee types (ITEmployee, SalesEmployee, etc.)
- Apply polymorphism for bonus calculation
- Separate display logic

## Exercise 2: Shopping Cart System

**Focus**: Collections, composition, strategy pattern, and business logic separation

**Procedural Code**

```csharp
public class ShoppingProcessor
{
    public static void ProcessOrder()
    {
        // Product data
        List<string> productNames = new List<string> { "Laptop", "Mouse", "Keyboard" };
        List<double> productPrices = new List<double> { 999.99, 29.99, 79.99 };
        List<int> quantities = new List<int> { 1, 2, 1 };
        List<string> categories = new List<string> { "Electronics", "Electronics", "Electronics" };
        
        // Customer data
        string customerName = "Alice Smith";
        string customerType = "Premium"; // Regular, Premium, VIP
        string shippingAddress = "123 Main St, City, State";
        
        // Calculate subtotal
        double subtotal = 0;
        for (int i = 0; i < productNames.Count; i++)
        {
            subtotal += productPrices[i] * quantities[i];
        }
        
        // Apply discount based on customer type
        double discount = 0;
        if (customerType == "Premium")
        {
            discount = subtotal * 0.10;
        }
        else if (customerType == "VIP")
        {
            discount = subtotal * 0.15;
        }
        
        // Calculate tax (different rates for different categories)
        double tax = 0;
        for (int i = 0; i < categories.Count; i++)
        {
            double itemTotal = productPrices[i] * quantities[i];
            if (categories[i] == "Electronics")
            {
                tax += itemTotal * 0.08;
            }
            else if (categories[i] == "Books")
            {
                tax += itemTotal * 0.05;
            }
            else
            {
                tax += itemTotal * 0.07;
            }
        }
        
        // Calculate shipping
        double shipping = 0;
        if (subtotal < 100)
        {
            shipping = 15.99;
        }
        else if (customerType == "VIP")
        {
            shipping = 0; // Free shipping for VIP
        }
        else
        {
            shipping = 9.99;
        }
        
        double total = subtotal - discount + tax + shipping;
        
        // Display order summary
        Console.WriteLine($"Customer: {customerName} ({customerType})");
        Console.WriteLine($"Shipping Address: {shippingAddress}");
        Console.WriteLine("--- Order Details ---");
        for (int i = 0; i < productNames.Count; i++)
        {
            Console.WriteLine($"{productNames[i]} x{quantities[i]} = ${productPrices[i] * quantities[i]}");
        }
        Console.WriteLine($"Subtotal: ${subtotal}");
        Console.WriteLine($"Discount: -${discount}");
        Console.WriteLine($"Tax: ${tax}");
        Console.WriteLine($"Shipping: ${shipping}");
        Console.WriteLine($"Total: ${total}");
    }
}
```