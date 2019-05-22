using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace RONC.Domain
{
    public class ApiWrapper
    {
        public List<object> GetArticles()
        {
            var apiResponse = MakeApiCall();
            
            var deserializedResult = JsonConvert.DeserializeObject<List<Article>>(apiResponse.Content);
            
            return new List<object>();
        }

        private RestResponse MakeApiCall()
        {
            var restClient = new RestClient("https://newsapi.org/v2/");
            
            var restCall = new RestRequest("top-headlines", Method.GET);
            restCall.AddParameter("country", "us");
            restCall.AddHeader("X-Api-Key", Environment.GetEnvironmentVariable("NEWS_API_KEY"));

            return (RestResponse)restClient.Execute(restCall);
        }
    }

    public class Article
    {
    }
}