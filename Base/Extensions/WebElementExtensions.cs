using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace TemplateFramework.Base.Extensions
{
    public static class WebElementExtensions
    {
        public static string GetValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static void ClearSendKeys(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static bool IsDisplayed(this IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public static bool AreDisplayed(this IList<IWebElement> elements)
        {
            return elements.All(element => element.IsDisplayed());
        }

        public static void CheckCheckbox(this IWebElement element)
        {
            CheckUncheckCheckbox(element, () => !element.IsCheckboxChecked());
        }

        public static void UncheckCheckbox(this IWebElement element)
        {
            CheckUncheckCheckbox(element, element.IsCheckboxChecked);
        }

        private static void CheckUncheckCheckbox(this IWebElement element, Func<bool> condition)
        {
            element = GetInputFromElement(element);

            if (condition.Invoke())
            {
                element.Click();
            }
        }

        public static bool IsCheckboxChecked(this IWebElement element)
        {
            return GetInputFromElement(element).Selected;
        }

        private static IWebElement GetInputFromElement(IWebElement element)
        {
            return element.TagName.Equals("input")
                ? element
                : element.FindElement(By.TagName("input"));
        }
    }
}
