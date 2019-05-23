using System.Collections.Generic;

namespace RONC.Domain.DataObject
{
    public class ArticleWrapper
    {
        public List<ApiDataResponse> Articles { get; set; }
        public string Status { get; set; }
        
        public string Message { get; set; }
    }
}