using System;
using OpenQA.Selenium.Firefox;

namespace RONC.UnitTest.FrontEndTests
{
    public class RONCWebDriver
    {
        private static RONCWebDriver instance;
        
        public static RONCWebDriver GetRONCWebDriver()
        {
            if (instance == null)
            {
                instance = new RONCWebDriver();
            }

            return instance;
        }

        public RONCWebDriver()
        {
            var driverName = GetGeckoDriverName();
            Driver = CreateFireFoxDriver();
        }
        
        public FirefoxDriver Driver { get; set; }

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

        public static FirefoxDriver CreateFireFoxDriver()
        {
            var driverName = GetGeckoDriverName();
            var service = FirefoxDriverService.CreateDefaultService(
                Environment.CurrentDirectory,
                driverName);
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            return new FirefoxDriver(service, options, TimeSpan.FromMinutes(3));
        }
    }
}