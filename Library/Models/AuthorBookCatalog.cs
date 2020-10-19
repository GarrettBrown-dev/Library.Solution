namespace Library.Models
{
  public class AuthorBookCatalog
  {
    public int AuthorBookCatalogId { get; set; }
    public int? AuthorId { get; set; }
    public int? BookId { get; set; }
    public int? CatalogId { get; set; }
    public Author Author { get; set; }
    public Book Book { get; set; }
    public Catalog Catalog { get; set; }
  }
}