using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Extensions
{
    public static class WebDriverHelper
    {
        public static IWebDriver SetupWebDriver()
        {
            string basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            var webDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService($"{basePath}Models", "chromedriver.exe"), chromeOptions);

            return webDriver;
        }
    }
}
