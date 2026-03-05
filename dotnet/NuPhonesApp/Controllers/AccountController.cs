using Microsoft.AspNetCore.Mvc;

namespace NuPhonesApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountController
        public ActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }

    }
}
