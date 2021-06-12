using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    public class BooksHttpClient
    {
        private readonly HttpClient _httpClient;

        public BooksHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Book>>("/api/books");
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync<Book>("/api/books",book);
            return await response.Content.ReadFromJsonAsync<Book>();
        }
    }
}