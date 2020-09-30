using OpenQA.Selenium;
using TemplateFramework.PageObjects.Products;

namespace TemplateFramework.PageObjects
{
    public class Pages
    {
        private readonly IWebDriver _driver;

        public Pages(IWebDriver driver)
        {
            _driver = driver;
        }

        public AlertPage AlertPage => new AlertPage(_driver);

        public NavigationPanel NavigationPanel => new NavigationPanel(_driver);
        public LoginForm LoginForm => new LoginForm(_driver);
        public ManageProductsPage ManageProductsPage => new ManageProductsPage(_driver);
        public ProductForm ProductForm => new ProductForm(_driver);
    }
}
