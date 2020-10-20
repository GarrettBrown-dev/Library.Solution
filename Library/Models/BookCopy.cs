namespace Library.Models
{
  public class BookCopy
  {
    public int BookCopyId { get; set; }
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
  }
}