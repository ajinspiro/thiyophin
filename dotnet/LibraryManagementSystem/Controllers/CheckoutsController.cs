using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class CheckoutsController : Controller
    {
        private readonly LibraryContext _context;

        public CheckoutsController(LibraryContext context)
        {
            _context = context;
        }
        // GET: CheckoutsController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetMembers()
        {
            var members = _context.Members
                .Select(m => new { m.Id, m.Name})
                .ToList();
            
            return Json(members);
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books
                .Select(b => new{b.Id, b.Name})
                .ToList();
            
            return Json(books);
        }
        [HttpGet]
        public IActionResult SearchMembers(string search)
        {
            var members = _context.Members
                .Where(m => m.Name.Contains(search))
                .Select(m => new {m.Id, m.Name})
                .ToList();
            return Json(members);
        }
        [HttpGet]
        public IActionResult SearchBooks(string search)
        {
            var books = _context.Books
                .Where(b => b.Name.Contains(search))
                .Select(b => new{ b.Id, b.Name})
                .ToList();

            return Json(books);
        }
   }
}