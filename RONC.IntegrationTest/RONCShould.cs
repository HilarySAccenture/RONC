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
        public void DisplayExpectedText()
        {
            var currentDirectory = Environment.CurrentDirectory;
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            Console.WriteLine($"this is the {_fileName}");
            
            var service = FirefoxDriverService.CreateDefaultService(currentDirectory, _fileName);
            var driver = new FirefoxDriver(service, options);

            var result = string.Empty;
            
            try
            {
                driver.Navigate().GoToUrl("http://localhost:8000");
                var page = driver.FindElementByTagName("pre");

                result = page.Text;
                
            }
            catch (WebDriverException wde)
            {
                
            }
            finally
            {
                driver.Quit();
            }

            result.ShouldContain("hello world");
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
    }
}