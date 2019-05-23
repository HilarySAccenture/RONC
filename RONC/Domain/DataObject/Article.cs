using System.Collections.Generic;

namespace RONC.Domain.DataObject
{
    public class ArticleWrapper
    {
        public List<Article> Articles { get; set; }
        public string Status { get; set; }
        
        public string Message { get; set; }
    }
    
    public class Article
    {
        public string Title { get; set; }
        public Error Error { get; set; }

        public Article(string errorMessage)
        {
            Error = new Error(errorMessage);
        }
    }
}