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
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://localhost:5000/home/index");

                pCount = driver.FindElementsByTagName("p").Count;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                driver.Quit();
            }
             
            pCount.ShouldBe(1);
            
        }
    }
}