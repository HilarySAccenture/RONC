using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace RONC.IntegrationTest
{
    public class RONCShould
    {
        private static string _fileName = GetGeckoDriverName();

        [Fact]
        public void DisplayExpectedTextInIndex()
        {
            var driver = CreateFirefoxDriver();

            var indexGreeting = string.Empty;
            var apiAttribution = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:8000");
                indexGreeting = driver.FindElementById("indexGreeting").Text;
                apiAttribution = driver.FindElementById("apiAttribution").Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                driver.Quit();
            }

            indexGreeting.ShouldContain("Hello World!");
            apiAttribution.ShouldContain("newsapi.org");
        }


        [Fact]
        public void GetArticleButtonReturnsArticle()
        {
            var driver = CreateFirefoxDriver();

            var articleGreeting = string.Empty;
            var articleTitle = string.Empty;
            var apiAttribution = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:8000");
                driver.FindElementById("btnGetArticle").Click();

                articleGreeting = driver.FindElementById("articleGreeting").Text;
                articleTitle = driver.FindElementById("articleTitle").Text;
                apiAttribution = driver.FindElementById("apiAttribution").Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                driver.Quit();
            }

            articleGreeting.ShouldContain("article for you");
            articleTitle.ShouldNotBeNullOrEmpty();
            apiAttribution.ShouldContain("newsapi.org");
        }
        
        [Fact]
        public void NavigateToApiUrlThroughAttributionLink()
        {
            var driver = CreateFirefoxDriver();

            var apiURL = string.Empty;

            try
            {
                driver.Navigate().GoToUrl("http://localhost:8000");
                driver.FindElementById("apiAttribution").Click();

                apiURL = driver.Url;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                driver.Quit();
            }

            apiURL.ShouldContain("newsapi.org");
        }


        private static string GetGeckoDriverName()
        {
            var remoteFileName = Environment.GetEnvironmentVariable("TravisWebDriver");
            var driverName = "geckodrivermac";

            if (remoteFileName != null)
            {
                driverName = remoteFileName;
            }

            return driverName;
        }

        private static FirefoxDriver CreateFirefoxDriver()
        {
            var currentDirectory = Environment.CurrentDirectory;
            var options = new FirefoxOptions();
            options.AddArgument("--headless");

            var service = FirefoxDriverService.CreateDefaultService(currentDirectory, _fileName);
            var driver = new FirefoxDriver(service, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            return driver;
        }
    }
}