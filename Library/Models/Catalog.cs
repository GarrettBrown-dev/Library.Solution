using System.Collections.Generic;

namespace Library.Models
{
  public class Catalog
  {
    public Catalog()
    {
      this.Books = new HashSet<BookCatalog>();
      this.Authors = new HashSet<BookCatalog>();
    }
    public int CatalogId { get; set; }
    public string CatalogName { get; set; }
    public virtual ICollection<BookCatalog> Books { get; set; }
    public virtual ICollection<BookCatalog> Authors { get; set; }
  }
}