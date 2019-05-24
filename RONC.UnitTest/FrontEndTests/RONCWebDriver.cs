using System;
using OpenQA.Selenium.Firefox;

namespace RONC.UnitTest.FrontEndTests
{
    public class RONCWebDriver
    {
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