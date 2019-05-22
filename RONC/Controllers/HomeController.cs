using Microsoft.AspNetCore.Mvc;

namespace RONC.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}