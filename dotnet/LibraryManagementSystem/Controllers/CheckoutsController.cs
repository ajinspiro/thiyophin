using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var checkouts = _context.Checkouts
                .Include(c => c.Book)
                .Include(c => c.Member)
                .Where(c => c.ReturnDate == null)
                .ToList();

            return View(checkouts);
        }
        [HttpGet]
        public IActionResult GetMembers()
        {
            var members = _context.Members
                .Select(m => new { m.Id, m.Name })
                .ToList();

            return Json(members);
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books
                .Select(b => new { b.Id, b.Name })
                .ToList();

            return Json(books);
        }
        [HttpGet]
        [HttpGet]
        public IActionResult SearchMembers(string search)
        {
            var members = _context.Members
                .Where(m => m.Name.ToLower() == search.ToLower())
                .Select(m => new { m.Id, m.Name })
                .ToList();

            return Json(members);
        }

        [HttpGet]
        public IActionResult SearchBooks(string search)
        {
            var books = _context.Books
                .Where(b => b.Name.Contains(search))
                .Select(b => new { b.Id, b.Name })
                .ToList();

            return Json(books);
        }
        public IActionResult CreateCheckout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCheckout(int memberId, int bookId)
        {
            var checkout = new Checkout
            {
                MemberId = memberId,
                BookId = bookId,
                CheckoutDate = DateTime.Now
            };

            _context.Checkouts.Add(checkout);
            _context.SaveChanges();

            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult CheckIn(int id)
        {
            var checkout = _context.Checkouts.FirstOrDefault(c => c.Id == id);

            if (checkout != null)
            {
                checkout.ReturnDate = DateTime.Now;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}