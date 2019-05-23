using System;
using Xunit;
using OpenQA.Selenium.Firefox;
using Shouldly;

namespace RONC.UnitTest
{
    public class IndexShould
    {
        private string _geckoDriver = GetGeckoDriverName();
        
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
        
        private FirefoxDriver CreateFireFoxDriver()
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
            FirefoxDriver driver = null;
            try
            {
                driver = CreateFireFoxDriver();

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
            FirefoxDriver driver = null;

            try
            {
                driver = CreateFireFoxDriver();

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
            FirefoxDriver driver = null;

            try
            {
                driver = CreateFireFoxDriver();

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
    }
}