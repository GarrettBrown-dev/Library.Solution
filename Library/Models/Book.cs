using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.Catalogs = new HashSet<BookCatalog>();
      this.Authors = new HashSet<BookCatalog>();
    }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public int BookCount { get; set; }
    public virtual ICollection<BookCatalog> Catalogs { get; set; }
    public virtual ICollection<BookCatalog> Authors { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}