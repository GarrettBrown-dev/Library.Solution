using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.JoinEntries = new HashSet<AuthorBookCatalog>();
    }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public int BookCount { get; set; }
    public virtual ICollection<AuthorBookCatalog> JoinEntries { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}