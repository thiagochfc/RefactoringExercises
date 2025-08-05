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

[OOP Code](./src/RefactoringExercises/ShoppingCartSystem/)

### Refactoring Goals

- Create Product, Customer, Order, and OrderItem classes
- Implement discount strategies for different customer types
- Create tax calculation service
- Implement shipping calculator
- Apply single responsibility principle
- Use composition and dependency injection

## Exercise 3: Library Management System

**Focus**: Complex domain modeling, repository pattern, events, and SOLID principles

**Procedural Code**

```csharp
public class LibraryManager
{
    private static List<string> bookTitles = new List<string>();
    private static List<string> bookAuthors = new List<string>();
    private static List<string> bookISBNs = new List<string>();
    private static List<bool> bookAvailability = new List<bool>();
    private static List<DateTime> bookDueDates = new List<DateTime>();
    private static List<string> borrowerNames = new List<string>();
    private static List<string> borrowerEmails = new List<string>();
    private static List<string> borrowerTypes = new List<string>(); // Student, Faculty, Public
    private static List<DateTime> borrowerRegistrationDates = new List<DateTime>();
    
    public static void BorrowBook(string isbn, string borrowerEmail)
    {
        int bookIndex = -1;
        int borrowerIndex = -1;
        
        // Find book
        for (int i = 0; i < bookISBNs.Count; i++)
        {
            if (bookISBNs[i] == isbn)
            {
                bookIndex = i;
                break;
            }
        }
        
        // Find borrower
        for (int i = 0; i < borrowerEmails.Count; i++)
        {
            if (borrowerEmails[i] == borrowerEmail)
            {
                borrowerIndex = i;
                break;
            }
        }
        
        if (bookIndex == -1)
        {
            Console.WriteLine("Book not found");
            return;
        }
        
        if (borrowerIndex == -1)
        {
            Console.WriteLine("Borrower not registered");
            return;
        }
        
        if (!bookAvailability[bookIndex])
        {
            Console.WriteLine("Book is not available");
            return;
        }
        
        // Check borrower limits
        int currentBorrowedCount = 0;
        for (int i = 0; i < bookDueDates.Count; i++)
        {
            if (bookDueDates[i] > DateTime.Now && !bookAvailability[i])
            {
                currentBorrowedCount++;
            }
        }
        
        int maxBooks = 0;
        if (borrowerTypes[borrowerIndex] == "Student")
        {
            maxBooks = 5;
        }
        else if (borrowerTypes[borrowerIndex] == "Faculty")
        {
            maxBooks = 10;
        }
        else
        {
            maxBooks = 3;
        }
        
        if (currentBorrowedCount >= maxBooks)
        {
            Console.WriteLine("Borrower has reached maximum book limit");
            return;
        }
        
        // Calculate due date
        int loanPeriodDays = 0;
        if (borrowerTypes[borrowerIndex] == "Student")
        {
            loanPeriodDays = 14;
        }
        else if (borrowerTypes[borrowerIndex] == "Faculty")
        {
            loanPeriodDays = 30;
        }
        else
        {
            loanPeriodDays = 7;
        }
        
        // Process borrowing
        bookAvailability[bookIndex] = false;
        bookDueDates[bookIndex] = DateTime.Now.AddDays(loanPeriodDays);
        
        Console.WriteLine($"Book '{bookTitles[bookIndex]}' borrowed successfully");
        Console.WriteLine($"Due date: {bookDueDates[bookIndex].ToShortDateString()}");
        
        // Check if borrower needs late fee notification
        DateTime registrationDate = borrowerRegistrationDates[borrowerIndex];
        if (DateTime.Now.Subtract(registrationDate).TotalDays > 365)
        {
            Console.WriteLine("Note: Please renew your library membership");
        }
    }
    
    public static void ReturnBook(string isbn)
    {
        int bookIndex = -1;
        
        // Find book
        for (int i = 0; i < bookISBNs.Count; i++)
        {
            if (bookISBNs[i] == isbn)
            {
                bookIndex = i;
                break;
            }
        }
        
        if (bookIndex == -1)
        {
            Console.WriteLine("Book not found");
            return;
        }
        
        if (bookAvailability[bookIndex])
        {
            Console.WriteLine("Book was not borrowed");
            return;
        }
        
        // Calculate late fee
        DateTime dueDate = bookDueDates[bookIndex];
        double lateFee = 0;
        
        if (DateTime.Now > dueDate)
        {
            int lateDays = (int)DateTime.Now.Subtract(dueDate).TotalDays;
            lateFee = lateDays * 0.50; // $0.50 per day
        }
        
        bookAvailability[bookIndex] = true;
        bookDueDates[bookIndex] = DateTime.MinValue;
        
        Console.WriteLine($"Book '{bookTitles[bookIndex]}' returned successfully");
        
        if (lateFee > 0)
        {
            Console.WriteLine($"Late fee: ${lateFee}");
        }
    }
    
    public static void DisplayOverdueBooks()
    {
        Console.WriteLine("=== Overdue Books ===");
        for (int i = 0; i < bookISBNs.Count; i++)
        {
            if (!bookAvailability[i] && DateTime.Now > bookDueDates[i])
            {
                int lateDays = (int)DateTime.Now.Subtract(bookDueDates[i]).TotalDays;
                Console.WriteLine($"{bookTitles[i]} - {lateDays} days overdue");
            }
        }
    }
}
```