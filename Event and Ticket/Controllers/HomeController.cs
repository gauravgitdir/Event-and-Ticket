using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List", "Ticket", new { area = "Ticket" });
        }

        public IActionResult About()
        {
           
            return View();
        }
    }
}
 