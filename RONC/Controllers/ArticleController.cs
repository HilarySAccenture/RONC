using System;
using Microsoft.AspNetCore.Mvc;
using RONC.Domain;
using RONC.Domain.Models;
using RONC.Models;

namespace RONC.Controllers
{
    public class ArticleController : Controller
    {
        private NewsService _newsService = new NewsService();
        public IActionResult GetArticle()
        {
            ArticleDomainModel domModel = null;
            var viewModel = new ArticleViewModel();
            
            try
            {
                domModel = _newsService.GetArticle();
                viewModel.Title = domModel.Title;
            }
            catch (Exception e)
            {
                viewModel.Title = e.Message;
            }
            
            return View("Article", viewModel);
        }
    }
}