using System.ComponentModel.DataAnnotations;

namespace BooksApp.Models
{
    public class Book
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Author { get; set; }
    }
}