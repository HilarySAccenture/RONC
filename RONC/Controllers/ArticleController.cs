using Microsoft.AspNetCore.Mvc;

namespace RONC.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult GetArticle()
        {
            return View("Article");
        }
    }
}