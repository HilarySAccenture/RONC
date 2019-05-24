using Microsoft.AspNetCore.Mvc;
using RONC.Domain.Models;
using RONC.Models;

namespace RONC.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult GetArticle()
        {
            // get view model from service
            // turn into a view model
            
            var model = new ArticleViewModel { Title = "Article for you"};
            
            return View("Article", model);
        }
    }
}