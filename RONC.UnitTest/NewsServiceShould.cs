using System.Collections.Generic;
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
            var service = new NewsService();

            var result = service.GetArticle();

            result.ShouldBeOfType<ArticleDomainModel>();
        }
        
    }
}