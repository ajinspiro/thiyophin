using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using NuPhonesApp.Data;
using NuPhonesApp.Models;
using NuPhonesApp.ViewModels;

namespace NuPhonesApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: AccountController
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(SignupViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Email = model.Email,
                Phone = model.Phone,
                Password = model.Password
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            _logger.LogInformation("User : {User}", user?.Username);
            if (user != null)
            {
                // Create Session
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("Username", user.Username);

                // Create Cookie
                var cookieoptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddHours(1)
                };
                Response.Cookies.Append("Username", user.Username, cookieoptions);
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
            }
            return View();
        }
    }
}
