using OpenQA.Selenium;
using System;

namespace TemplateFramework.Base.Extensions.WebDriver
{
    public static class NavigationExtensions
    {
        public static void Open(this IWebDriver driver, Uri url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void Open(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void MaximizeScreen(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void Refresh(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }


        public static string GetUrl(this IWebDriver driver)
        {
            return driver.Url;
        }
    }
}
