using RONC.Domain.Models;

namespace RONC.Domain
{
    public class NewsService
    {
        private IApiCaller _caller;

        public NewsService(IApiCaller caller)
        {
            _caller = caller;
        }
        
        public ArticleDomainModel GetArticle()
        {
            var resultString = _caller.GetArticlesAsJson();
            
            return new ArticleDomainModel { ApiCallResultValue = resultString };
        }
    }
}