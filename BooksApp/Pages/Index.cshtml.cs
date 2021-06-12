using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BooksApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BooksHttpClient _booksHttpClient;
        public List<Book> Books { get; set; }
        
        [BindProperty]
        public Book Book { get; set; }
        public IndexModel(ILogger<IndexModel> logger, BooksHttpClient booksHttpClient)
        {
            _logger = logger;
            _booksHttpClient = booksHttpClient;
        }

        public async Task OnGet()
        {
            Books = await _booksHttpClient.GetBooksAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            await _booksHttpClient.CreateBookAsync(Book);
            return RedirectToPage("./Index");
        }
    }
}
