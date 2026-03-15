using Microsoft.AspNetCore.Mvc;

namespace NuPhonesApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username");
            ViewBag.Username = username;
            return View();
        }

        public IActionResult Logout()
        {
            // Clear session
            HttpContext.Session.Clear();

            // Remove cookie
            Response.Cookies.Delete("Username");

            return RedirectToAction("Index", "Home");
        }

    }
}
