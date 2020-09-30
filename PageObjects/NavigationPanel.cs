using OpenQA.Selenium;
using TemplateFramework.Base.Extensions;

namespace TemplateFramework.PageObjects
{
    public class NavigationPanel
    {
        private readonly IWebDriver _driver;

        public NavigationPanel(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement LoginButton => _driver.FindElement(By.ClassName("login-button"));
        private IWebElement UserEmailDropdown => _driver.FindElement(By.ClassName("user-email-dropdown"));
        private IWebElement ManageProductsLink => _driver.FindElement(By.ClassName("manage-products"));

        public bool IsUserEmailDisplayed => UserEmailDropdown.IsDisplayed();

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void GoToManageProducts()
        {
            UserEmailDropdown.Click();
            ManageProductsLink.Click();
        }
    }
}
