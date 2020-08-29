using LLibrary;
using NUnit.Framework;
using OpenQA.Selenium;
using TemplateFramework.Helpers;

namespace TemplateFramework.Base
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            var driverConfig = Configuration.WebDriver;
            var logger = new L();
            Driver = new WebDriverFactory().GetWebDriver(driverConfig, logger);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        protected IWebDriver Driver { get; set; }
    }
}
