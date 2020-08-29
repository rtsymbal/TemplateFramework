using OpenQA.Selenium;

namespace TemplateFramework.Base.Extensions
{
    public static class WebElementExtensions
    {
        public static string GetValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }
    }
}
