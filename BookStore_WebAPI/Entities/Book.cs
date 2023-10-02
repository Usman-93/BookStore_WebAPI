using System.ComponentModel.DataAnnotations;

namespace BookStore_WebAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Title { get; set; }

        [Required]
        [StringLength(50)]
        public required string Author { get; set; }

        [Range(5, 500)]
        public int Price { get; set; }
        public int publishedYear { get; set; }

    }
}
