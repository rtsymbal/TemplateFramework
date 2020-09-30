using OpenQA.Selenium;
using TemplateFramework.Models;

namespace TemplateFramework.PageObjects
{
    public class LoginForm
    {
        private readonly IWebDriver _driver;

        public LoginForm(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement EmailInput => _driver.FindElement(By.Id("login-email"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("login-password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-btn"));

        public void Login(User user)
        {
            EmailInput.SendKeys(user.Email);
            PasswordInput.SendKeys(user.Password);
            LoginButton.Click();
        }
    }
}
