using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers;

public class BooksController : Controller
{
    private readonly LibraryContext _context;

    public BooksController(LibraryContext context)
    {
        _context = context;
    }

    // GET /Books
    public IActionResult Index()
    {
        return View(_context.Books.ToList());
    }
    [HttpPost]
    public IActionResult Search(string search)
    {
        var searchResults = _context.Books.Where(x => x.Name.Contains(search)).ToList();
        ViewBag.Search = search; // store the search value
        return View(searchResults);
    }
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(string BookName, string ISBN)
    {
        Book obj = new Book();
        obj.Name = BookName;
        obj.ISBN = ISBN;
        obj.AddedOn = DateTime.Now;
        obj.IsCheckedOut = true;
        _context.Books.Add(obj);
        int result = _context.SaveChanges();
        return Redirect("/Books");
    }

}
