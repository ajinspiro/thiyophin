using System;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem2_0.Controllers;

public class MembersController : Controller
{
    private readonly LibraryContext _context;

    public MembersController(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? search)
    {
        ViewData["Title"] = "Members";

        var query = _context.Members.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(m => m.FullName.Contains(search));
        }

        var members = await query
            .OrderByDescending(m => m.JoinedOn)
            .ToListAsync();

        ViewBag.Search = search;

        return View(members);
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Add member";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Member member)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Title"] = "Add member";
            return View(member);
        }

        member.JoinedOn = DateTime.UtcNow;
        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}

