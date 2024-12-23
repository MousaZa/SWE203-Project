using System.ComponentModel.DataAnnotations;

namespace UniProject.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Author { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        public int PageNumbers { get; set; }
    }
}