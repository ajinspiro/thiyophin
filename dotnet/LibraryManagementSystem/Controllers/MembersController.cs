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
        Member obj = new Member();
        obj.Name = Name;
        obj.Email = Email;
        obj.Phone = Phone;
        obj.JoinedOn = DateTime.Now;
        _context.Members.Add(obj);
        int result = _context.SaveChanges();
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