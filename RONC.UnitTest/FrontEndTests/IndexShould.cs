using System;
using OpenQA.Selenium.Firefox;
using Shouldly;
using Xunit;
using Xunit.Sdk;

namespace RONC.UnitTest.FrontEndTests
{
    public class IndexShould
    {
        private FirefoxDriver driver = CreateFireFoxDriver();
        private static string _geckoDriver = GetGeckoDriverName();

        public static string GetGeckoDriverName()
        {
            var remoteFileName = Environment.GetEnvironmentVariable("TravisWebDriver");
            var driverName = "geckodrivermac";

            if (remoteFileName != null)
            {
                driverName = remoteFileName;
            }

            return driverName;
        }

        public static FirefoxDriver CreateFireFoxDriver()
        {
            var service = FirefoxDriverService.CreateDefaultService(
                Environment.CurrentDirectory,
                _geckoDriver);
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            return new FirefoxDriver(service, options);
        }

        [Fact]
        public void RenderAParagraphTag()
        {
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