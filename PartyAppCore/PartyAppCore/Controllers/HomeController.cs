using Microsoft.AspNetCore.Mvc;

namespace PartyAppCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
