using System.Collections.Generic;

namespace Library.Models
{
  public class Catalog
  {
    public Catalog()
    {
      this.JoinEntries = new HashSet<AuthorBookCatalog>();
    }
    public int CatalogId { get; set; }
    public string CatalogName { get; set; }
    public virtual ICollection<AuthorBookCatalog> JoinEntries { get; set; }
  }
}