using System;
using OpenQA.Selenium.Firefox;
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

                title = driver.FindElementById("greeting").Text;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                driver.Quit();
            }
            title.ShouldContain("Article for you");
        }
        
        [Fact]
        public void ReturnArticleViewWithArticleTitle()
        {
            driver = CreateFireFoxDriver();
            var title = string.Empty;
            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/article/getarticle");

                title = driver.FindElementById("articleTitle").Text;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                driver.Quit();
            }
            
            title.ShouldContain("Killer tomatoes! From Space!");
        }
    }
}