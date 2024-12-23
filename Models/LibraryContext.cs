using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace UniProject.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;

        public static void Seed(LibraryContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Description = "A novel set in the Jazz Age.", PageNumbers = 180 },
                    new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Description = "A novel about racial injustice.", PageNumbers = 281 },
                    new Book { Title = "1984", Author = "George Orwell", Description = "A dystopian novel.", PageNumbers = 328 },
                    new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Description = "A romantic novel.", PageNumbers = 279 }
                );
                context.SaveChanges();
            }
        }
    }
}