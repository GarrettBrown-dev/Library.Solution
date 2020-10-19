using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
  public class LibraryContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Catalog> Catalogs { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public DbSet<AuthorBookCatalog> AuthorBookCatalog { get; set; }
    public LibraryContext(DbContextOptions options) : base(options) { }
  }
}