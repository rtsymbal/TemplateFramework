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
    }
}
