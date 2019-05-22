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

            return new List<Article>
            {
                new Article
                {
                    Error = new Error() 
                } 
            };
        }
    }
}