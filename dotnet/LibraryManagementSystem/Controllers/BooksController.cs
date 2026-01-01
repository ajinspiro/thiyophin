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
        return Json(_context.Books.ToList());
    }

    // POST /Books/Add
    [HttpPost]
    public IActionResult Add([FromBody] Book book)
    {
        book.AddedOn = DateTime.Now;
        book.IsCheckedOut = false;
        _context.Books.Add(book);
        _context.SaveChanges();
        return Ok(book);
    }

    // GET /Books/Delete/3
    public IActionResult Delete(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null || book.IsCheckedOut)
            return BadRequest("Cannot delete");

        _context.Books.Remove(book);
        _context.SaveChanges();
        return Ok();
    }
}
