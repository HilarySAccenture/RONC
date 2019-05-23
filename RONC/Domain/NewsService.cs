using System;
using System.Collections.Generic;
using System.Linq;
using RONC.Domain.DataObject;
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

            var articleDomainModel = CreateArticleDomainModel(deserializedResult);

            return articleDomainModel;
        }

        private ArticleDomainModel CreateArticleDomainModel(List<ApiDataResponse> deserializedResult)
        {
            var articleDomainModel = new ArticleDomainModel();

            if (deserializedResult != null && deserializedResult.Count > 0)
            {
                if (deserializedResult[0].Error != null)
                {
                    throw new Exception(deserializedResult[0].Error.Message);
                }

                articleDomainModel.Title = deserializedResult[0].Title;
            }
            else
            {
                throw new Exception("Response was null or empty");
            }

            return articleDomainModel;
        }
    }
}