using System.Collections.Generic;

namespace Library.Models
{
  public class Author
  {
    public Author()
    {
      this.Catalogs = new HashSet<BookCatalog>();
      this.Books = new HashSet<BookCatalog>();
    }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }

    public virtual ICollection<BookCatalog> Catalogs { get; set; }
    public virtual ICollection<BookCatalog> Books { get; set; }
  }
}