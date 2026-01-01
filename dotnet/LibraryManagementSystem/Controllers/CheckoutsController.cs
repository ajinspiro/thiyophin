using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers;

public class CheckoutsController : Controller
{
    // GET /Checkouts
    public IActionResult Index()
    {
        return Content("Checkouts coming next");
    }
}
