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
    public ICollection<BookCopy> Checkouts { get; set; }
  }
}