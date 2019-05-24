using System;
using OpenQA.Selenium.Firefox;
using Shouldly;
using Xunit;
using static RONC.UnitTest.FrontEndTests.RONCWebDriver;

namespace RONC.UnitTest.FrontEndTests
{
    public class IndexShould
    {
        
        private FirefoxDriver driver;

        [Fact]
        public void RenderAParagraphTag()
        {
            driver = CreateFireFoxDriver();
            
            var pCount = 0;
            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/home/index");

                pCount = driver.FindElementsByTagName("p").Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                driver.Quit();
            }

            pCount.ShouldBe(1);
        }

        [Fact]
        public void RenderCorrectTextInParagraphTag()
        {
            driver = CreateFireFoxDriver();
            
            var pText = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/home/index");

                pText = driver.FindElementByTagName("p").Text;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                driver.Quit();
            }

            pText.ShouldBe("Hello World!");
        }

        [Fact]
        public void RenderAButton()
        {
            driver = CreateFireFoxDriver();
            
            var buttonText = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/home/index");

                buttonText = driver.FindElementById("btnGetArticle").Text;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                driver.Quit();
            }

            buttonText.ShouldBe("Get Article");
        }

        [Fact]
        public void ReturnAnArticleView()
        {
            driver = CreateFireFoxDriver();
            
            var page = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:5000/home/index");

                driver.FindElementById("btnGetArticle").Click();

                page = driver.Url;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                driver.Quit();
            }

            page.ShouldContain("article");
        }
        
        
    }
}