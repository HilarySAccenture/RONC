using System.Linq;
using RONC.Domain.Models;

namespace RONC.Domain
{
    public class NewsService
    {
        private IApiCaller _caller;
        private IArticleDeserializer _deserializer;

        public NewsService(IApiCaller caller, IArticleDeserializer deserializer)
        {
            _caller = caller;
            _deserializer = deserializer;
        }
        
        public ArticleDomainModel GetArticle()
        {
            var resultString = _caller.GetArticlesAsJson();

            var deserializedResult = _deserializer.Convert(resultString);
            
            return new ArticleDomainModel { DeserializedResult = deserializedResult };
        }
    }
}