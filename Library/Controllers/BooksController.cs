using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;

namespace Library.Controllers
{
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;

    public BooksController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Book> model = _db.Books.ToList();
      return View(model);
    }
    [Authorize(Roles = "Administrator")]
    public ActionResult Create()
    {
      return View();
    }
    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Create(Book book)
    {
      _db.Books.Add(book);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisBook = _db.Books
        .Include(book => book.JoinEntries)
        .ThenInclude(join => join.Author)
        .Include(book => book.BookCopies)
        .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }
    public ActionResult Edit(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book)
    {
      _db.Entry(book).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = book.BookId });
    }
    public ActionResult Delete(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteAuthor(int joinId, int bookId)
    {
      var joinEntry = _db.AuthorBookCatalog.FirstOrDefault(entry => entry.AuthorBookCatalogId == joinId);
      _db.AuthorBookCatalog.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = bookId });
    }
    public ActionResult AddAuthor(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
      return View(thisBook);
    }
    [HttpPost]
    public ActionResult AddAuthor(Book book, int AuthorId)
    {
      if (AuthorId != 0)
      {
        _db.AuthorBookCatalog.Add(new AuthorBookCatalog() { AuthorId = AuthorId, BookId = book.BookId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = book.BookId });
    }
    [HttpPost]
    public ActionResult Search(string search)
    {
      List<Book> searchList = _db.Books.Include(x => x.JoinEntries).ToList();
      List<Book> model = Book.Search(searchList, search);
      return View(model);
    }
    [HttpPost]
    public ActionResult AddCopy(BookCopy bookCopy)
    {
      _db.BookCopies.Add(bookCopy);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
