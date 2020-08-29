using OpenQA.Selenium;

namespace TemplateFramework.Base.Extensions.WebDriver
{
    public static class LocalStorageExtensions
    {
        public static void SetLocalStorageItem(this IWebDriver driver, string itemName, object value)
        {
            driver.ExecuteScript($"localStorage.setItem('{itemName}', '{value}')");
        }

        public static string GetFromLocalStorage(this IWebDriver driver, string itemName)
        {
            return driver.ExecuteScript($"return localStorage.getItem('{itemName}')").ToString();
        }

        private static object ExecuteScript(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
    }
}
