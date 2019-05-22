using System.Collections.Generic;

namespace RONC.Domain.DataObject
{
    public class ArticleWrapper
    {
        public List<Article> Articles { get; set; }
    }
    
    
    public class Article
    {
        public string Title { get; set; }
    }
}