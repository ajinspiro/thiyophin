using System;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem2_0.Controllers;

public class CheckoutsController : Controller
{
    private readonly LibraryContext _context;

    public CheckoutsController(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Checkouts";

        var items = await _context.Checkouts
            .Include(c => c.Member)
            .Include(c => c.Book)
            .Where(c => c.ReturnedAt == null)
            .OrderByDescending(c => c.CheckedOutAt)
            .Select(c => new CheckoutListItemViewModel
            {
                Id = c.Id,
                BookTitle = c.Book != null ? c.Book.Title : string.Empty,
                BookIsbn = c.Book != null ? c.Book.Isbn : string.Empty,
                MemberName = c.Member != null ? c.Member.FullName : string.Empty,
                CheckedOutAt = c.CheckedOutAt
            })
            .ToListAsync();

        return View(items);
    }

    public async Task<IActionResult> Create(string? memberSearch, string? bookSearch)
    {
        ViewData["Title"] = "Checkout";

        var model = new CheckoutCreateViewModel
        {
            MemberSearch = memberSearch,
            BookSearch = bookSearch
        };

        var membersQuery = _context.Members.AsQueryable();
        if (!string.IsNullOrWhiteSpace(memberSearch))
        {
            membersQuery = membersQuery.Where(m => m.FullName.Contains(memberSearch));
        }

        var booksQuery = _context.Books.AsQueryable();
        if (!string.IsNullOrWhiteSpace(bookSearch))
        {
            booksQuery = booksQuery.Where(b => b.Title.Contains(bookSearch));
        }

        model.Members = await membersQuery
            .OrderBy(m => m.FullName)
            .Take(20)
            .ToListAsync();

        model.Books = await booksQuery
            .OrderBy(b => b.Title)
            .Take(20)
            .ToListAsync();

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CheckoutCreateViewModel model)
    {
        if (!model.SelectedMemberId.HasValue)
        {
            ModelState.AddModelError(nameof(model.SelectedMemberId), "Please select a member.");
        }

        if (!model.SelectedBookId.HasValue)
        {
            ModelState.AddModelError(nameof(model.SelectedBookId), "Please select a book.");
        }

        if (!ModelState.IsValid)
        {
            return await Create(model.MemberSearch, model.BookSearch);
        }

        var checkout = new Checkout
        {
            MemberId = model.SelectedMemberId.Value,
            BookId = model.SelectedBookId.Value,
            CheckedOutAt = DateTime.UtcNow
        };

        _context.Checkouts.Add(checkout);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CheckIn(int id)
    {
        var checkout = await _context.Checkouts.FindAsync(id);

        if (checkout != null && checkout.ReturnedAt == null)
        {
            checkout.ReturnedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}

