namespace RefactoringExercises.LibraryManagementSystem;

public class LibraryManager(
    List<string> bookTitles,
    List<string> bookAuthors,
    List<string> bookISBNs,
    List<bool> bookAvailability,
    List<DateTime> bookDueDates,
    List<string> borrowerNames,
    List<string> borrowerEmails,
    List<string> borrowerTypes,
    List<DateTime> borrowerRegistrationDates)
{
    public void BorrowBook(string isbn, string borrowerEmail)
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
    
    public void ReturnBook(string isbn)
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
    
    public void DisplayOverdueBooks()
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