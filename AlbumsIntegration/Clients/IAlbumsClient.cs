using AlbumsIntegration.Dtos;

namespace AlbumsIntegration.Clients;
public interface IAlbumsClient
{
    Task<IEnumerable<Book>> ListBooksAsync();
    Task CheckoutBookAsync(string title);
    Task ReturnBookAsync(string title);
    Task<IEnumerable<Book>> ListCheckedOutBooksAsync();

}
