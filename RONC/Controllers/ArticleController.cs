using Microsoft.AspNetCore.Mvc;
using RONC.Domain;
using RONC.Domain.Models;
using RONC.Models;

namespace RONC.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult GetArticle()
        {
            // get domain model from service
            // turn into a view model
            var domModel = new ArticleDomainModel {Title = "Killer tomatoes! From Space!"};
            
            var model = new ArticleViewModel { Title = domModel.Title};
            
            return View("Article", model);
        }
    }
}