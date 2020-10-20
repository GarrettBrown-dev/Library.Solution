using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Library.Models;
using System.Threading.Tasks;
using Library.ViewModels;
using System.Security.Claims;
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

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userCheckedOutBooks = _db.Checkouts
      .Include(bookCopy => bookCopy.BookCopy)
      .Where(entry => entry.Patron.Id == currentUser.Id).ToList();
      return View(userCheckedOutBooks);
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
      return View();
    }
    // [HttpPost]
    // public ActionResult CheckBook(Patron patron, int BookCopyId)
    // {
    //   if (BookCopyId != 0)
    //   {
    //     _db.Checkouts.Add(new Checkout() { BookCopyId = BookCopyId, PatronId = patron.PatronId });
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}

