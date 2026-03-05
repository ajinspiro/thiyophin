using Microsoft.AspNetCore.Mvc;

namespace NuPhonesApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
