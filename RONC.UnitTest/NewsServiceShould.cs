using System;
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
        public void ReturnDomainModelWithCorrectTitle()
        {
            var mockApiReturn = new ApiDataResponse {Title = "Bob"};
            mockDeserializer.Convert(Arg.Any<string>()).Returns(new List<ApiDataResponse> {mockApiReturn});
            var service = new NewsService(mockCaller, mockDeserializer); 
            
            var result = service.GetArticle();

            result.Title.ShouldBe("Bob");
        }

        [Fact]
        public void ThrowExceptionWithErrorMessageWhenApiDataResponseHasAnError()
        {
            var mockApiReturn = new ApiDataResponse("error");
            mockDeserializer.Convert(Arg.Any<string>()).Returns(new List<ApiDataResponse> {mockApiReturn});
            var service = new NewsService(mockCaller, mockDeserializer); 
            
            Should.Throw<Exception>(() => service.GetArticle()).Message.ShouldBe("error");
            
        }
    }
}