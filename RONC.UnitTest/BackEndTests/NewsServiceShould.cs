using System;
using System.Collections.Generic;
using NSubstitute;
using RONC.Domain;
using RONC.Domain.DataObject;
using Shouldly;
using Xunit;

namespace RONC.UnitTest.BackEndTests
{
    public class NewsServiceShould
    {
        private IApiCaller mockCaller = Substitute.For<IApiCaller>();
        private IArticleDeserializer mockDeserializer = Substitute.For<IArticleDeserializer>();
        
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

        [Fact]
        public void ThrowExceptionIfApiDataResponseIsEmpty()
        {
            mockDeserializer.Convert(Arg.Any<string>()).Returns(new List<ApiDataResponse>());
            var service = new NewsService(mockCaller, mockDeserializer);

            Should.Throw<Exception>(() => service.GetArticle()).Message.ShouldBe("Response was null or empty");
        }

        [Fact]
        public void ReturnFirstArticleIfReceivesMoreThanOneArticle()
        {
            var mockApiReturn1 = new ApiDataResponse {Title = "Bob"};
            var mockApiReturn2 = new ApiDataResponse {Title = "Ross"};
            mockDeserializer.Convert(Arg.Any<string>()).Returns(new List<ApiDataResponse> {mockApiReturn1, mockApiReturn2});
            var service = new NewsService(mockCaller, mockDeserializer); 
            
            var result = service.GetArticle();

            result.Title.ShouldBe("Bob");
        }
    }
}