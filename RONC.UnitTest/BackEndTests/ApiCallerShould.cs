using System.Linq;
using NSubstitute;
using RestSharp;
using RONC.Domain;
using Shouldly;
using Xunit;

namespace RONC.UnitTest.BackEndTests
{
    public class ApiCallerShould
    {
        [Fact]
        public void Exist()
        {
            var caller = new ApiCaller();
            
            caller.ShouldNotBeNull();
        }

        [Fact]
        public void ReturnAStringWhenGetArticlesAsJsonCalled()
        {
            var _client = Substitute.For<IRestClient>();
            var _response = Substitute.For<IRestResponse>();
            _response.Content.Returns("cat");
            _client.Execute(Arg.Any<IRestRequest>()).Returns(_response);
            string _apiKey = null;
            
            var caller = new ApiCaller(_client, _apiKey);

            var response = caller.GetArticlesAsJson();

            response.ShouldNotBeNullOrEmpty();
        }
        
        [Fact]
        public void ReturnStringErrorWhenGetArticlesAsJsonCalledAndNoApiKey()
        {
            string _apiKey = null;
            var _client = Substitute.For<IRestClient>();
            var caller = new ApiCaller(_client, _apiKey);

            var response = caller.GetArticlesAsJson();

            var arguments = (RestRequest)_client.ReceivedCalls().First().GetArguments().First();

            var xApiKey = arguments.Parameters.FirstOrDefault(param => param.Name == "X-Api-Key");

            xApiKey.Value.ShouldBeNull();
        }

        
    }
}