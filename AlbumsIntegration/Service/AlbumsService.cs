using AlbumsIntegration.Clients;
using AlbumsIntegration.Dtos;

namespace AlbumsIntegration.Service;
public class AlbumsService : IAlbumsService
{
    private IAlbumsClient _albumsClient;

    public AlbumsService(IAlbumsClient albumsClient)
    {
        _albumsClient = albumsClient;
    }

    public async Task CheckoutBookAsync(string title)
    {
        await _albumsClient.CheckoutBookAsync(title);
    }

    public async Task<IEnumerable<Book>> ListCheckedOutBooksAsync()
    {
        return await _albumsClient.ListCheckedOutBooksAsync();
    }

    public async Task<IEnumerable<Book>> ListBooksAsync()
    {
        return await _albumsClient.ListBooksAsync();
    }

    public async Task ReturnBookAsync(string title)
    {
        await _albumsClient.ReturnBookAsync(title);
    }
}
