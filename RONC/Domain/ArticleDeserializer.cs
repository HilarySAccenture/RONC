using System.Collections.Generic;
using Newtonsoft.Json;
using RONC.Domain.DataObject;

namespace RONC.Domain
{
    public class ArticleDeserializer
    {
        public List<ApiDataResponse> Convert(string testString)
        {
            var articleWrapper = JsonConvert.DeserializeObject<ArticleWrapper>(testString);

            if (articleWrapper.Status == "ok")
            {
                return articleWrapper.Articles;
            }

            return CreateErrorArticle(articleWrapper.Message);
        }

        private static List<ApiDataResponse> CreateErrorArticle(string errorMessage)
        {
            return new List<ApiDataResponse>
            {
                new ApiDataResponse(errorMessage)
            };
        }
    }
}