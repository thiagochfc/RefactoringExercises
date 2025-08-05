namespace RefactoringExercises.Application;

public static class LibraryManagementSystem
{
    private static List<string> bookTitles = [];
    private static List<string> bookAuthors = [];
    private static List<string> bookISBNs = [];
    private static List<bool> bookAvailability = [];
    private static List<DateTime> bookDueDates = [];
    private static List<string> borrowerNames = [];
    private static List<string> borrowerEmails = [];
    private static List<string> borrowerTypes = []; // Student, Faculty, Public
    private static List<DateTime> borrowerRegistrationDates = [];
    public static void Execute()
    {
        Console.WriteLine("=== LIBRARY MANAGEMENT SYSTEM (PROCEDURAL) ===\n");
        
        // Setup initial data (simulating the static lists from procedural code)
        SetupLibraryData();
        
        Console.WriteLine("Initial Library State:");
        Console.WriteLine($"Books in system: {bookTitles.Count}");
        Console.WriteLine($"Registered borrowers: {borrowerNames.Count}\n");
        
        // Example 1: Alice (Student) borrowing Clean Code
        Console.WriteLine("1. Alice trying to borrow 'Clean Code':");
        BorrowBook("978-0132350884", "alice@email.com");
        Console.WriteLine();
        
        // Expected output from procedural code:
        // Book 'Clean Code' borrowed successfully
        // Due date: 2025-08-19
        
        // Example 2: Dr. Smith (Faculty) borrowing Design Patterns  
        Console.WriteLine("2. Dr. Smith trying to borrow 'Design Patterns':");
        BorrowBook("978-0201633612", "smith@university.edu");
        Console.WriteLine();
        
        // Expected output:
        // Book 'Design Patterns' borrowed successfully
        // Due date: 2025-09-04
        
        // Example 3: John trying to borrow already borrowed book
        Console.WriteLine("3. John trying to borrow 'Clean Code' (already borrowed):");
        BorrowBook("978-0132350884", "john@gmail.com");
        Console.WriteLine();
        
        // Expected output:
        // Book is not available
        
        // Example 4: Invalid book ISBN
        Console.WriteLine("4. Trying to borrow non-existent book:");
        BorrowBook("999-INVALID", "alice@email.com");
        Console.WriteLine();
        
        // Expected output:
        // Book not found
        
        // Example 5: Unregistered borrower
        Console.WriteLine("5. Unregistered person trying to borrow:");
        BorrowBook("978-0134757599", "unknown@email.com");
        Console.WriteLine();
        
        // Expected output:
        // Borrower not registered
        
        // Example 6: Student trying to exceed book limit
        Console.WriteLine("6. Alice trying to borrow more books (testing limit):");
        
        // First, let's borrow 4 more books to reach the limit
        BorrowBook("978-0201633612", "alice@email.com"); // Design Patterns
        BorrowBook("978-0134757599", "alice@email.com"); // Refactoring
        BorrowBook("978-0321125215", "alice@email.com"); // Domain-Driven Design
        BorrowBook("978-0134494166", "alice@email.com"); // Clean Architecture
        
        // Now try to borrow the 6th book (should fail - student limit is 5)
        Console.WriteLine("Trying to borrow 6th book:");
        BorrowBook("978-0596007126", "alice@email.com"); // Head First Design Patterns
        Console.WriteLine();
        
        // Expected output:
        // Borrower has reached maximum book limit
        
        // Example 7: Return a book (on time)
        Console.WriteLine("7. Alice returning 'Design Patterns' on time:");
        ReturnBook("978-0201633612");
        Console.WriteLine();
        
        // Expected output:
        // Book 'Design Patterns' returned successfully
        
        // Example 8: Return a book (late) - simulate by manipulating due dates
        Console.WriteLine("8. Simulating late return:");
        // In procedural code, we'd need to manipulate the bookDueDates array
        // to simulate overdue books, then call ReturnBook
        SimulateOverdueReturn();
        Console.WriteLine();
        
        // Example 9: Display all overdue books
        Console.WriteLine("9. Current overdue books:");
        DisplayOverdueBooks();
        Console.WriteLine();
        
        // Example 10: Borrower with expired membership
        Console.WriteLine("10. Testing membership renewal notification:");
        // Simulate old registration date and try to borrow
        SimulateOldMembershipBorrow();
        Console.WriteLine();
    }
    
    private static void SetupLibraryData()
    {
        // Simulate adding books to the static arrays
        AddBook("Clean Code", "Robert Martin", "978-0132350884");
        AddBook("Design Patterns", "Gang of Four", "978-0201633612");
        AddBook("Refactoring", "Martin Fowler", "978-0134757599");
        AddBook("Domain-Driven Design", "Eric Evans", "978-0321125215");
        AddBook("Clean Architecture", "Robert Martin", "978-0134494166");
        AddBook("Head First Design Patterns", "Freeman & Robson", "978-0596007126");
        
        // Add borrowers
        AddBorrower("Alice Johnson", "alice@email.com", "Student");
        AddBorrower("Dr. Smith", "smith@university.edu", "Faculty");
        AddBorrower("John Doe", "john@gmail.com", "Public");
    }
    
    private static void AddBook(string title, string author, string isbn)
    {
        bookTitles.Add(title);
        bookAuthors.Add(author);
        bookISBNs.Add(isbn);
        bookAvailability.Add(true);
        bookDueDates.Add(DateTime.MinValue);
    }
    
    private static void AddBorrower(string name, string email, string type)
    {
        borrowerNames.Add(name);
        borrowerEmails.Add(email);
        borrowerTypes.Add(type);
        borrowerRegistrationDates.Add(DateTime.Now);
    }
    
    private static void SimulateOverdueReturn()
    {
        // Find Clean Code and make it overdue
        int cleanCodeIndex = bookISBNs.FindIndex(isbn => isbn == "978-0132350884");
        if (cleanCodeIndex >= 0)
        {
            // Make it overdue by 5 days
            bookDueDates[cleanCodeIndex] = DateTime.Now.AddDays(-5);
            
            Console.WriteLine("Alice returning 'Clean Code' (5 days late):");
            ReturnBook("978-0132350884");
        }
    }
    
    private static void SimulateOldMembershipBorrow()
    {
        // Find John and set his registration date to over a year ago
        int johnIndex = borrowerEmails.FindIndex(email => email == "john@gmail.com");
        if (johnIndex >= 0)
        {
            borrowerRegistrationDates[johnIndex] = DateTime.Now.AddDays(-400);
            
            Console.WriteLine("John (old membership) trying to borrow 'Refactoring':");
            BorrowBook("978-0134757599", "john@gmail.com");
        }
    }
    
    private static void BorrowBook(string isbn, string borrowerEmail)
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
    
    private static void ReturnBook(string isbn)
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
    
    private static void DisplayOverdueBooks()
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