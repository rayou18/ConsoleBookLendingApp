using AlbumsIntegration.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlbumsIntegration.Clients;
public class AlbumsClient : IAlbumsClient
{
    private Dictionary<string, Book> checkedOutBooks = new();
    private readonly HttpClient _httpClient = new();

    public async Task CheckoutBookAsync(string title)
    {
        if (checkedOutBooks.ContainsKey(title)) {
            Console.WriteLine("Book has already been checked out...");
            return;
        }

        var bookSelection = await ListBooksAsync();
        if (!bookSelection.Any(book => book.Title == title))
        {
            Console.WriteLine("Book is not part of available selection...");
            return;
        }

        checkedOutBooks.Add(title, bookSelection.First(book => book.Title == title));
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Book>> ListCheckedOutBooksAsync()
    {
        return await Task.FromResult(checkedOutBooks.Values.AsEnumerable<Book>());
    }

    public async Task<IEnumerable<Book>> ListBooksAsync()
    {
        var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users/1/albums");
        response.EnsureSuccessStatusCode();
        string body = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<Book> >(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true}) ?? [];
    }

    public async Task ReturnBookAsync(string title)
    {
        if (!checkedOutBooks.Values.Any(book => book.Title == title))
        {
            Console.WriteLine("You cannot return a book you don't have...");
            return;
        }

        checkedOutBooks.Remove(title);

        await Task.CompletedTask;
    }
}
