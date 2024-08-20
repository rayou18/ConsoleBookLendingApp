using AlbumsIntegration.Dtos;

namespace AlbumsIntegration.Service;
public interface IAlbumsService
{
    Task<IEnumerable<Book>> ListBooksAsync();
    Task CheckoutBookAsync(string title);
    Task ReturnBookAsync(string title);
    Task<IEnumerable<Book>> ListCheckedOutBooksAsync();
}
