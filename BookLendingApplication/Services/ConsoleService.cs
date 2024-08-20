using BookLendingApplication.Dtos;

namespace BookLendingApplication.Services;
public class ConsoleService : IConsoleService
{
    private readonly IBookLendingService _bookLendingService;

    public ConsoleService(IBookLendingService bookLendingService)
    {
        _bookLendingService = bookLendingService;
    }

    public async Task RunAsync()
    {
        bool running = true;
        Console.WriteLine("\r\n  ____              _      _                    _           \r\n |  _ \\            | |    | |                  | |          \r\n | |_) | ___   ___ | | __ | |     ___ _ __   __| | ___ _ __ \r\n |  _ < / _ \\ / _ \\| |/ / | |    / _ \\ '_ \\ / _` |/ _ \\ '__|\r\n | |_) | (_) | (_) |   <  | |___|  __/ | | | (_| |  __/ |   \r\n |____/ \\___/ \\___/|_|\\_\\ |______\\___|_| |_|\\__,_|\\___|_|   \r\n                                                            \r\n                                                            \r\n");
        Console.WriteLine("################################################################");

        while (running)
        {
            Console.WriteLine("Enter a command (type 'help' for available commands): ");
            string input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var command = parts[0].ToLower();
            var arguments = parts.Length > 1 ? parts[1..] : [];


            switch (command)
            {
                case "help":
                    DisplayHelp();
                    break;

                case "exit":
                    Console.WriteLine("Exiting the application...");
                    running = false;
                    Environment.Exit(0);
                    break;

                case "list-all":
                case "ls":
                    var books = await _bookLendingService.ListAllBooksAsync();
                    PrintBooks(books);
                    break;
                case "list-checked-out":
                case "lco":
                    var checkedOutBooks = await _bookLendingService.ListCheckedOutBooksAsync();
                    PrintBooks(checkedOutBooks);
                    break;
                case "checkout-book":
                    if (arguments.Length == 0)
                    {
                        Console.WriteLine("missing book title argument..");
                        break;
                    }
                    await _bookLendingService.CheckoutBookAsync(string.Join(" ", arguments));
                    break;
                case "return-book":
                    if (arguments.Length == 0)
                    {
                        Console.WriteLine("missing book title argument..");
                        break;
                    }
                    await _bookLendingService.ReturnBookAsync(string.Join(" ", arguments));
                    break;

                default:
                    Console.WriteLine("Unknown command or argument. Type 'help' to see available commands.");
                    break;
            }
        }
    }

    private void PrintBooks(IEnumerable<Book> books)
    {
        foreach (var book in books)
        {
            Console.WriteLine("### ID: {0,-18} | User ID: {1,-18} | Title: {2,-50} ###", book.Id, book.UserId, book.Title);
        }
    }

    private void DisplayHelp()
    {
        Console.WriteLine("\nAvailable Commands:");
        Console.WriteLine("_____________________________________________________________");
        Console.WriteLine("* help - Show available commands");
        Console.WriteLine("* list-all, ls - lists available selection");
        Console.WriteLine("* list-checked-out, lco - lists currently checked out books");
        Console.WriteLine("* checkout-book <title of your book> - checks out book e.g. checkout-book harry potter");
        Console.WriteLine("* return-book <title of your book> - returns book e.g. return-book harry potter");
        Console.WriteLine("* exit - closes the application");
        Console.WriteLine("_____________________________________________________________");

    }

}
