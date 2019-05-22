using Microsoft.AspNetCore.Mvc;

namespace RONC
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