using System.Collections.Generic;
using NSubstitute;
using RONC.Domain;
using RONC.Domain.DataObject;
using RONC.Domain.Models;
using Shouldly;
using Xunit;

namespace RONC.UnitTest
{
    public class NewsServiceShould
    {
        private IApiCaller mockCaller = Substitute.For<IApiCaller>();
        private IArticleDeserializer mockDeserializer = Substitute.For<IArticleDeserializer>();
        
        [Fact]
        public void ReturnAnArticleDomainModel()
        {
            var service = new NewsService(mockCaller, mockDeserializer);

            var result = service.GetArticle();

            result.ShouldBeOfType<ArticleDomainModel>();
        }

        [Fact]
        public void ReturnDomainModelWithValue()
        {
            mockCaller.GetArticlesAsJson().Returns("I am a value oh yes");
            var service = new NewsService(mockCaller, mockDeserializer);

            var result = service.GetArticle();

            result.ApiCallResultValue.ShouldContain("a value");
        }

        [Fact]
        public void ReturnDomainModelWithDeserializedApiReturn()
        {
            var mockApiReturn = new ApiDataResponse {Title = "Bob"};
            mockDeserializer.Convert(Arg.Any<string>()).Returns(new List<ApiDataResponse> {mockApiReturn});
            var service = new NewsService(mockCaller, mockDeserializer);

            var result = service.GetArticle();

            result.DeserializedResult.ShouldBeOfType<List<ApiDataResponse>>();
        }
        
    }
}