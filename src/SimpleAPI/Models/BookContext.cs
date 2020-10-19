using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Models
{
  public class BookContext : DbContext
  {
    public BookContext(DbContextOptions<BookContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
  }
}
