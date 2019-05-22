using System;
using RestSharp;

namespace RONC.Domain
{
    public class ApiCaller :IApiCaller
    {
        private RestClient _client;
        private string _apiKey;
        public ApiCaller()
        { 
            _client = new RestClient("https://newsapi.org/v2"); 
            _apiKey = Environment.GetEnvironmentVariable("NEWS_API_KEY");
        }
        
        public string GetArticlesAsJson()
        {
            var request = CreateRestRequest();

            var response = _client.Execute(request);

            return response.Content;
        }

        private RestRequest CreateRestRequest()
        {
            var request = new RestRequest("top-headlines", Method.GET);
            request.AddParameter("country", "us");
            request.AddHeader("X-Api-Key", _apiKey);
            
            return request;
        }
    }
}