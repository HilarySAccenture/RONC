using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Shouldly;
using Xunit.Sdk;

namespace RONC.UnitTest
{
    public class IndexShould
    {
        [Fact]
        public void RenderAParagraphTag()
        {
            var pCount = 0;
            FirefoxDriver driver = null;
            try
            {
                var options = new FirefoxOptions();
               // options.AddArgument("--headless");
                driver = new FirefoxDriver();

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
                var options = new FirefoxOptions();
                options.AddArgument("--headless");
                driver = new FirefoxDriver(options);

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
    }
}