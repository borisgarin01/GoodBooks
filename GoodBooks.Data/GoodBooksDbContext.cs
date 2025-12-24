using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;

namespace GoodBooks.Data;

public class GoodBooksDbContext : DbContext
{
    public GoodBooksDbContext(DbContextOptions<GoodBooksDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<BookReview> BooksReviews { get; set; }
}
