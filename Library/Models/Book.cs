using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.JoinEntries = new HashSet<AuthorBookCatalog>();
      this.BookCopies = new HashSet<BookCopy>();
    }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public virtual ICollection<BookCopy> BookCopies { get; set; }
    public virtual ICollection<AuthorBookCatalog> JoinEntries { get; set; }
    public virtual Patron Patron { get; set; }
    public static List<Book> Search(List<Book> allObject, string searchParam)
    {
      List<Book> matches = new List<Book> { };
      if (searchParam != null)
      {
        foreach (Book x in allObject)
        {
          if (x.BookName.ToUpper().Contains(searchParam.ToUpper()))
          {
            matches.Add(x);
          }
        }
      }
      return matches;
    }
  }
}