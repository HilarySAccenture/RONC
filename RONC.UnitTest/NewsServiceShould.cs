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
        [Fact]
        public void ReturnAnArticleDomainModel()
        {
            var mockCaller = Substitute.For<IApiCaller>();
            
            var service = new NewsService(mockCaller);

            var result = service.GetArticle();

            result.ShouldBeOfType<ArticleDomainModel>();
        }

        [Fact]
        public void ReturnDomainModelWithValueThatsNotNull()
        {
            var mockCaller = Substitute.For<IApiCaller>();
            mockCaller.GetArticlesAsJson().Returns("I am a value oh yes");
            var service = new NewsService(mockCaller);

            var result = service.GetArticle();

            result.ApiCallResultValue.ShouldNotBeNullOrEmpty();
        }
        
    }
}