using System.Collections.Generic;

namespace Library.Models
{
  public class Author
  {
    public Author()
    {
      this.JoinEntries = new HashSet<AuthorBookCatalog>();
    }
    public int AuthorId { get; set; }
    public int AuthorCount { get; set; }
    public string AuthorName { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<AuthorBookCatalog> JoinEntries { get; set; }
  }
}