using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers;

public class MembersController : Controller
{
    private readonly LibraryContext _context;

    public MembersController(LibraryContext context)
    {
        _context = context;
    }

    // GET / or /Members
    public IActionResult Index()
    {
        return View(_context.Members.ToList());
    }

    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(string Name, string Email, string Phone)
    {
        // Check if email already exists
        bool emailExists = _context.Members.Any(m => m.Email == Email);

        if (emailExists)
        {
            ViewBag.Error = "This email is already registered.";
            return View(); // Return to the same Add view with error
        }

        Member obj = new Member
        {
            Name = Name,
            Email = Email,
            Phone = Phone,
            JoinedOn = DateTime.Now
        };

        _context.Members.Add(obj);
        _context.SaveChanges();

        return Redirect("/");
    }


    [HttpPost]
    public IActionResult Search(string search)
    {
        var searchResults = _context.Members.Where(x => x.Name.Contains(search)).ToList();
        ViewBag.Search = search; // store the search value
        return View(searchResults);
    }
}