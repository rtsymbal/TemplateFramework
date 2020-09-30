using OpenQA.Selenium;
using TemplateFramework.Base.Extensions;

namespace TemplateFramework.PageObjects
{
    public class AlertPage
    {
        private readonly IWebDriver _driver;

        public AlertPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Alert => _driver.FindElement(By.ClassName("alert"));

        public bool IsAlertDisplayed => Alert.IsDisplayed();

        public string GetAlertText()
        {
            return Alert.Text;
        }
    }
}
