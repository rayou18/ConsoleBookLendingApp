using BookLendingApplication.Dtos;

namespace BookLendingApplication.Services;
public interface IBookLendingService
{
    Task<IEnumerable<Book>> ListAllBooksAsync();
    Task CheckoutBookAsync(string title);
    Task ReturnBookAsync(string title);
    Task<IEnumerable<Book>> ListCheckedOutBooksAsync();
}
