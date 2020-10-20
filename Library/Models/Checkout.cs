namespace Library.Models
{
  public class Checkout
  {
    public int CheckoutId { get; set; }
    public int BookCopyId { get; set; }
    public Patron Patron { get; set; }
    public BookCopy BookCopy { get; set; }
  }
}