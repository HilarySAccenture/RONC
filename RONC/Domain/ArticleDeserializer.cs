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
            
            return articleWrapper.Articles;
        }
    }
}