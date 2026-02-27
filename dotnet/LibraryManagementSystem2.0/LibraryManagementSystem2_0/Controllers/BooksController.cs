using System;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem2_0.Controllers;

public class BooksController : Controller
{
    private readonly LibraryContext _context;

    public BooksController(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? search)
    {
        ViewData["Title"] = "Books";

        var query = _context.Books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(b => b.Title.Contains(search));
        }

        var books = await query
            .OrderByDescending(b => b.AddedOn)
            .Select(b => new BookListItemViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Isbn = b.Isbn,
                AddedOn = b.AddedOn,
                IsOut = b.Checkouts.Any(c => c.ReturnedAt == null)
            })
            .ToListAsync();

        ViewBag.Search = search;

        return View(books);
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Add book";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Title"] = "Add book";
            return View(book);
        }

        book.AddedOn = DateTime.UtcNow;
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}

