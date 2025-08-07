using RefactoringExercises.LibraryManagementSystem;

namespace RefactoringExercises.Application;

public static class LibraryManagementSystem
{
    private static readonly List<string> BookTitles = [];
    private static readonly List<string> BookAuthors = [];
    private static readonly List<string> BookIsbNs = [];
    private static readonly List<bool> BookAvailability = [];
    private static readonly List<DateTime> BookDueDates = [];
    private static readonly List<string> BorrowerNames = [];
    private static readonly List<string> BorrowerEmails = [];
    private static readonly List<string> BorrowerTypes = []; // Student, Faculty, Public
    private static readonly List<DateTime> BorrowerRegistrationDates = [];

    public static void Execute()
    {
        LibraryManager libraryManager = new(BookTitles, BookAuthors, BookIsbNs, BookAvailability, BookDueDates,
            BorrowerNames, BorrowerEmails, BorrowerTypes, BorrowerRegistrationDates);
        
        Console.WriteLine("=== LIBRARY MANAGEMENT SYSTEM (PROCEDURAL) ===\n");

        // Setup initial data (simulating the static lists from procedural code)
        SetupLibraryData();

        Console.WriteLine("Initial Library State:");
        Console.WriteLine($"Books in system: {BookTitles.Count}");
        Console.WriteLine($"Registered borrowers: {BorrowerNames.Count}\n");

        // Example 1: Alice (Student) borrowing Clean Code
        Console.WriteLine("1. Alice trying to borrow 'Clean Code':");
        libraryManager.BorrowBook("978-0132350884", "alice@email.com");
        Console.WriteLine();

        // Expected output from procedural code:
        // Book 'Clean Code' borrowed successfully
        // Due date: 2025-08-19

        // Example 2: Dr. Smith (Faculty) borrowing Design Patterns  
        Console.WriteLine("2. Dr. Smith trying to borrow 'Design Patterns':");
        libraryManager.BorrowBook("978-0201633612", "smith@university.edu");
        Console.WriteLine();

        // Expected output:
        // Book 'Design Patterns' borrowed successfully
        // Due date: 2025-09-04

        // Example 3: John trying to borrow already borrowed book
        Console.WriteLine("3. John trying to borrow 'Clean Code' (already borrowed):");
        libraryManager.BorrowBook("978-0132350884", "john@gmail.com");
        Console.WriteLine();

        // Expected output:
        // Book is not available

        // Example 4: Invalid book ISBN
        Console.WriteLine("4. Trying to borrow non-existent book:");
        libraryManager.BorrowBook("999-INVALID", "alice@email.com");
        Console.WriteLine();

        // Expected output:
        // Book not found

        // Example 5: Unregistered borrower
        Console.WriteLine("5. Unregistered person trying to borrow:");
        libraryManager.BorrowBook("978-0134757599", "unknown@email.com");
        Console.WriteLine();

        // Expected output:
        // Borrower not registered

        // Example 6: Student trying to exceed book limit
        Console.WriteLine("6. Alice trying to borrow more books (testing limit):");

        // First, let's borrow 4 more books to reach the limit
        libraryManager.BorrowBook("978-0201633612", "alice@email.com"); // Design Patterns
        libraryManager.BorrowBook("978-0134757599", "alice@email.com"); // Refactoring
        libraryManager.BorrowBook("978-0321125215", "alice@email.com"); // Domain-Driven Design
        libraryManager.BorrowBook("978-0134494166", "alice@email.com"); // Clean Architecture

        // Now try to borrow the 6th book (should fail - student limit is 5)
        Console.WriteLine("Trying to borrow 6th book:");
        libraryManager.BorrowBook("978-0596007126", "alice@email.com"); // Head First Design Patterns
        Console.WriteLine();

        // Expected output:
        // Borrower has reached maximum book limit

        // Example 7: Return a book (on time)
        Console.WriteLine("7. Alice returning 'Design Patterns' on time:");
        libraryManager.ReturnBook("978-0201633612");
        Console.WriteLine();

        // Expected output:
        // Book 'Design Patterns' returned successfully

        // Example 8: Return a book (late) - simulate by manipulating due dates
        Console.WriteLine("8. Simulating late return:");
        // In procedural code, we'd need to manipulate the bookDueDates array
        // to simulate overdue books, then call ReturnBook
        SimulateOverdueReturn(libraryManager);
        Console.WriteLine();

        // Example 9: Display all overdue books
        Console.WriteLine("9. Current overdue books:");
        libraryManager.DisplayOverdueBooks();
        Console.WriteLine();

        // Example 10: Borrower with expired membership
        Console.WriteLine("10. Testing membership renewal notification:");
        // Simulate old registration date and try to borrow
        SimulateOldMembershipBorrow(libraryManager);
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
        BookTitles.Add(title);
        BookAuthors.Add(author);
        BookIsbNs.Add(isbn);
        BookAvailability.Add(true);
        BookDueDates.Add(DateTime.MinValue);
    }

    private static void AddBorrower(string name, string email, string type)
    {
        BorrowerNames.Add(name);
        BorrowerEmails.Add(email);
        BorrowerTypes.Add(type);
        BorrowerRegistrationDates.Add(DateTime.Now);
    }

    private static void SimulateOverdueReturn(LibraryManager libraryManager)
    {
        // Find Clean Code and make it overdue
        int cleanCodeIndex = BookIsbNs.FindIndex(isbn => isbn == "978-0132350884");
        if (cleanCodeIndex >= 0)
        {
            // Make it overdue by 5 days
            BookDueDates[cleanCodeIndex] = DateTime.Now.AddDays(-5);

            Console.WriteLine("Alice returning 'Clean Code' (5 days late):");
            libraryManager.ReturnBook("978-0132350884");
        }
    }

    private static void SimulateOldMembershipBorrow(LibraryManager libraryManager)
    {
        // Find John and set his registration date to over a year ago
        int johnIndex = BorrowerEmails.FindIndex(email => email == "john@gmail.com");
        if (johnIndex >= 0)
        {
            BorrowerRegistrationDates[johnIndex] = DateTime.Now.AddDays(-400);

            Console.WriteLine("John (old membership) trying to borrow 'Refactoring':");
            libraryManager.BorrowBook("978-0134757599", "john@gmail.com");
        }
    }
}