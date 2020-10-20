using System.Collections.Generic;

namespace Library.Models
{
  public class ManageUsersViewModel
  {
    public Patron[] Administrators { get; set; }

    public Patron[] Everyone { get; set; }
  }
}