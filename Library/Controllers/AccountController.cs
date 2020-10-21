using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Library.Models;
using System.Threading.Tasks;
using Library.ViewModels;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
  public class AccountController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<Patron> _userManager;
    private readonly SignInManager<Patron> _signInManager;

    public AccountController(UserManager<Patron> userManager, SignInManager<Patron> signInManager, LibraryContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<Book> modelBook = _db.Books.ToList();
      List<Checkout> modelCheckout = _db.Checkouts.Include(x => x.BookCopy).ThenInclude(x => x.Book).ToList();
      ViewBag.Book = modelBook;
      ViewBag.Checkout = modelCheckout;
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new Patron { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }
    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
    public ActionResult CheckBook()
    {
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName");
      return View();
    }
    [HttpPost]
    public ActionResult CheckBook(Patron patron, int BookId)
    {
      if (BookId != 0)
      {
        Book userBook = _db.Books.FirstOrDefault(x => x.BookId == BookId);
        int BookCopyId = userBook.GetBookCopyId();
        if (_db.Checkouts.Where(x => x.BookCopyId == BookCopyId && x.Patron.PatronId == patron.PatronId).ToHashSet().Count == 0)
        {
          _db.Checkouts.Add(new Checkout() { BookCopyId = BookCopyId, Patron = patron });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}


// var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
// var currentUser = await _userManager.FindByIdAsync(userId);
// var userCheckedOutBooks = _db.Checkouts
// .Include(bookCopy => bookCopy.BookCopy)
// .ThenInclude(checkout => checkout.CheckoutId)
// .Where(entry => entry.Patron.Id == currentUser.Id).ToList();
// return View(userCheckedOutBooks);