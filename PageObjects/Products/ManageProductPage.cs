using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TemplateFramework.Base.Extensions;
using TemplateFramework.Models;

namespace TemplateFramework.PageObjects.Products
{
    public class ManageProductsPage
    {
        private readonly IWebDriver _driver;

        public ManageProductsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement NewProductButton => _driver.FindElement(By.ClassName("new-product-btn"));
        private IWebElement SearchField => _driver.FindElement(By.Id("search"));
        private IEnumerable<IWebElement> TableRows => _driver.FindElements(By.CssSelector(".data-table-row-wrapper tr"));

        private static IWebElement TitleLabel(ISearchContext row) => row.FindElement(By.ClassName("column-title"));
        private static IWebElement PriceLabel(ISearchContext row) => row.FindElement(By.ClassName("column-price"));
        private static IWebElement EditButton(ISearchContext row) => row.FindElement(By.Id("edit"));

        public void GoToNewProductForm()
        {
            NewProductButton.Click();
        }

        public bool IsProductDisplayed(Product product)
        {
            SearchProduct(product.Title);

            var firstRow = TableRows.FirstOrDefault();

            return TableRows.Any() &&
                   TitleLabel(firstRow).Text.Equals(product.Title) &&
                   PriceLabel(firstRow).Text.Equals($"${product.Price:n}");
        }

        public void GoToEditProductForm(Product product)
        {
            SearchProduct(product.Title);
            EditButton(TableRows.FirstOrDefault()).Click();
        }

        private void SearchProduct(string productName)
        {
            SearchField.ClearSendKeys(productName);
        }
    }
}
