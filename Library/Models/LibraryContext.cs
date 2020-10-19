using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
  public class LibraryContext : DbContext
  {
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Catalog> Catalogs { get; set; }
    public DbSet<BookCatalog> BookCatalog { get; set; }
    public LibraryContext(DbContextOptions options) : base(options) { }
  }
}