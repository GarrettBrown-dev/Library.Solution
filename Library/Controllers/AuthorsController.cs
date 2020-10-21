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
  public class AuthorsController : Controller
  {
    private readonly LibraryContext _db;

    public AuthorsController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Author> model = _db.Authors.ToList();
      return View(model);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Create()
    {
      return View();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Create(Author author)
    {
      _db.Authors.Add(author);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisAuthor = _db.Authors
        .Include(author => author.JoinEntries)
        .ThenInclude(join => join.Book)
        .FirstOrDefault(author => author.AuthorId == id);
      return View(thisAuthor);
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Edit(int id)
    {
      var thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName");
      return View(thisAuthor);
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult Edit(Author author)
    {
      _db.Entry(author).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = author.AuthorId });
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult Delete(int id)
    {
      var thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
      return View(thisAuthor);
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
      _db.Authors.Remove(thisAuthor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult DeleteBook(int joinId, int authorId)
    {
      var joinEntry = _db.AuthorBookCatalog.FirstOrDefault(entry => entry.AuthorBookCatalogId == joinId);
      _db.AuthorBookCatalog.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = authorId });
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult AddBook(int id)
    {
      var thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName");
      return View(thisAuthor);
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public ActionResult AddBook(Author author, int BookId)
    {
      if (BookId != 0)
      {
        _db.AuthorBookCatalog.Add(new AuthorBookCatalog() { BookId = BookId, AuthorId = author.AuthorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = author.AuthorId });
    }
  }
}