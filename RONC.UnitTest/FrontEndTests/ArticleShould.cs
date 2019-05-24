using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using Xunit;
using static RONC.UnitTest.FrontEndTests.RONCWebDriver;

namespace RONC.UnitTest.FrontEndTests
{
    
    public class ArticleShould
    {
        private FirefoxDriver driver;

        [Fact]
        public void ReturnArticleViewWithGreetingValue()
        {
            driver = CreateFireFoxDriver();
            var title = string.Empty;
            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/article/getarticle");

                title = driver.FindElementById("articleGreeting").Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                driver.Quit();
            }
            title.ShouldContain("Article for you");
        }

        [Fact]
        public void DisplayAttributionLinkToNewsApi()
        {
            driver = CreateFireFoxDriver();
            var attribute = string.Empty;
            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/article/getarticle");

                attribute = driver.FindElementById("apiAttribution").Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                driver.Quit();
            }
            
            attribute.ShouldContain("NewsApi.org");
        }
    }
}