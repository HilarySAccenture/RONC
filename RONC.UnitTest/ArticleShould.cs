using System;
using OpenQA.Selenium.Firefox;
using Shouldly;
using Xunit;

namespace RONC.UnitTest
{
    public class ArticleShould
    {
        private string _geckoDriver = IndexShould.GetGeckoDriverName();
        
       
        [Fact]
        public void ReturnArticleViewWithGreetingValue()
        {
            FirefoxDriver driver = null;
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
    }
}