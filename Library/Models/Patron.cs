using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Library.Models
{
  public class Patron : IdentityUser
  {
    public Patron()
    {
      this.Checkouts = new HashSet<BookCopy>();
    }
    public int PatronId { get; set; }
    public int BookCopyId { get; set; }
    public ICollection<BookCopy> Checkouts { get; set; }
  }
}