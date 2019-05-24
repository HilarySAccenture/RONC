using System;
using OpenQA.Selenium.Firefox;
using Shouldly;
using Xunit;

namespace RONC.UnitTest.FrontEndTests
{
    public class ArticleShould
    {
        private string _geckoDriver = IndexShould.GetGeckoDriverName();
        private FirefoxDriver driver = IndexShould.CreateFireFoxDriver();
       
        [Fact]
        public void ReturnArticleViewWithGreetingValue()
        {
            var title = string.Empty;
            try
            {
                driver = IndexShould.CreateFireFoxDriver();
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
            var title = string.Empty;
            try
            {
                driver = IndexShould.CreateFireFoxDriver();
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