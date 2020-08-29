using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TemplateFramework.Helpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TemplateFramework.Base.Extensions.WebDriver
{
    public static class WaitExtension
    {
        public static WebDriverWait Wait(this IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Configuration.WebDriver.DefaultTimeout));
        }

        public static void WaitForClickable(this IWebDriver driver, By by)
        {
            driver.Wait().Until(ExpectedConditions.ElementToBeClickable(@by));
        }

        public static void WaitForClickable(this IWebDriver driver, IWebElement element)
        {
            driver.Wait().Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitFor(this IWebDriver driver, Func<bool> condition, string errorMessage = null)
        {
            try
            {
                var timeout = TestConfiguration.DriverSettings.WaitTimeout;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(d => condition());
            }
            catch (WebDriverTimeoutException)
            {
                if (errorMessage != null)
                {
                    throw new WebDriverTimeoutException(errorMessage);
                }

                throw;
            }
        }

        public static bool WaitToCheck(this IWebDriver driver, Func<bool> condition)
        {
            try
            {
                driver.WaitFor(condition);

                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
