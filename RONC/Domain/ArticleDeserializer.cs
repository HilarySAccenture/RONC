using System.Collections.Generic;
using Newtonsoft.Json;
using RONC.Domain.DataObject;

namespace RONC.Domain
{
    public class ArticleDeserializer
    {
        public List<Article> Convert(string testString)
        {
            var articleWrapper = JsonConvert.DeserializeObject<ArticleWrapper>(testString);

            if (articleWrapper.Status == "ok")
            {
                return articleWrapper.Articles;
            }

            return CreateErrorArticle(articleWrapper.Message);
        }

        private static List<Article> CreateErrorArticle(string errorMessage)
        {
            return new List<Article>
            {
                new Article(errorMessage)
            };
        }
    }
}