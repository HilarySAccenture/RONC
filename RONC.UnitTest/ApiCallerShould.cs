using RestSharp;
using RONC.Domain;
using Xunit;
using Shouldly;
using NSubstitute;

namespace RONC.UnitTest
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
            var _apiKey = string.Empty;
            
            var caller = new ApiCaller(_client, _apiKey);

            var response = caller.GetArticlesAsJson();

            response.ShouldNotBeNullOrEmpty();
        }

    }
}