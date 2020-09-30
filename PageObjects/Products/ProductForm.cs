using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TemplateFramework.Base.Extensions;
using TemplateFramework.Helpers;
using TemplateFramework.Models;

namespace TemplateFramework.PageObjects.Products
{
    public class ProductForm
    {
        private readonly IWebDriver _driver;

        public ProductForm(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement TitleField => _driver.FindElement(By.Id("title"));
        private IWebElement PriceField => _driver.FindElement(By.Id("price"));
        private IList<IWebElement> CategoryCheckboxes => _driver.FindElements(By.ClassName("category-checkbox"));
        private IWebElement ImageUrlField => _driver.FindElement(By.Id("imageUrl"));
        private IWebElement SaveButton => _driver.FindElement(By.Id("save"));

        public bool IsTitleFieldDisplayed => TitleField.IsDisplayed();
        public bool IsPriceFieldDisplayed => PriceField.IsDisplayed();
        public bool AreCategoryCheckboxesDisplayed => CategoryCheckboxes.AreDisplayed();
        public bool IsImageUrlFieldDisplayed => ImageUrlField.IsDisplayed();

        public void ClickSave()
        {
            SaveButton.Click();
        }

        public string GetTitleFieldValue()
        {
            return TitleField.GetValue();
        }
        public decimal GetPriceFieldValue()
        {
            return Convert.ToDecimal(PriceField.GetValue());
        }
        public Categories GetSelectedCheckbox()
        {
            var checkboxValue = CategoryCheckboxes.FirstOrDefault(x => x.IsCheckboxChecked())?.Text;
            return EnumHelper.FromDisplayString<Categories>(checkboxValue);
        }
        public string GetImageUrlFieldValue()
        {
            return ImageUrlField.GetValue();
        }

        public void FillForm(Product product)
        {
            FillTitleField(product.Title);
            FillPriceField(product.Price);
            SelectCategory(product.Category);
            FillImageUrl(product.ImageUrl);
        }

        public void FillTitleField(string title)
        {
            TitleField.ClearSendKeys(title);
        }

        public void FillPriceField(decimal price)
        {
            PriceField.ClearSendKeys(price.ToString(CultureInfo.InvariantCulture));
        }

        public void SelectCategory(Categories category)
        {
            var categoryElement = CategoryCheckboxes.FirstOrDefault(c => c.Text.Equals(category.ToDisplayString()));
            categoryElement.CheckCheckbox();
        }

        public void UnselectCategory(Categories category)
        {
            var categoryElement = CategoryCheckboxes.FirstOrDefault(c => c.Text.Equals(category.ToDisplayString()));
            categoryElement.UncheckCheckbox();
        }

        public void FillImageUrl(string url)
        {
            ImageUrlField.ClearSendKeys(url);
        }
    }
}
