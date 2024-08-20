using AlbumsIntegration.Service;
using BookLendingApplication.Dtos;
using BookLendingApplication.Mappers;

namespace BookLendingApplication.Services;
public class BookLendingService : IBookLendingService
{
    private readonly IAlbumsService _albumsService;
    private readonly IMapper<AlbumsIntegration.Dtos.Book, Dtos.Book> _bookMapper;

    public BookLendingService(
        IAlbumsService albumsService,
        IMapper<AlbumsIntegration.Dtos.Book, Dtos.Book> bookMapper)
    {
        _albumsService = albumsService;
        _bookMapper = bookMapper;
    }

    public async Task CheckoutBookAsync(string title)
    {
        await _albumsService.CheckoutBookAsync(title);
    }

    public async Task<IEnumerable<Book>> ListAllBooksAsync()
    {
        return (await _albumsService.ListBooksAsync()).Select(_bookMapper.Map);
    }

    public async Task<IEnumerable<Book>> ListCheckedOutBooksAsync()
    {
        return (await _albumsService.ListCheckedOutBooksAsync()).Select(_bookMapper.Map); ;
    }

    public async Task ReturnBookAsync(string title)
    {
        await _albumsService.ReturnBookAsync(title);
    }
}
