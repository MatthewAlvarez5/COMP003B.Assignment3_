using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment3.Models
{
    public class Book
    {
        [Required]
        [Range(0, 10000000000)]
        public int ISBN { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Author { get; set; }
        [Required]
        [StringLength(1000)]
        public string Genre { get; set; }
        [Required]
        [Range(0, 2023)]
        public int ReleaseYear { get; set; }

    }
}
