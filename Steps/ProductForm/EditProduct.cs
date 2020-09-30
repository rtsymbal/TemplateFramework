using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using TemplateFramework.Base.Enums;
using TemplateFramework.Base.Extensions.WebDriver;
using TemplateFramework.Models;
using TemplateFramework.Pipeline;
using TemplateFramework.Providers;

namespace TemplateFramework.Steps.ProductForm
{
    public class EditProduct : StepComposition, IStep
    {
        [Required]
        public Product ProductToEdit { get; set; }

        [Required]
        public Product EditedProduct { get; set; }

        public void Execute()
        {
            if (!ProductToEdit.Title.Equals(EditedProduct.Title))
            {
                Pages.ProductForm.FillTitleField(EditedProduct.Title);
            }

            if (!ProductToEdit.Price.Equals(EditedProduct.Price))
            {
                Pages.ProductForm.FillPriceField(EditedProduct.Price);
            }

            if (!ProductToEdit.Category.Equals(EditedProduct.Category))
            {
                Pages.ProductForm.UnselectCategory(ProductToEdit.Category);
                Pages.ProductForm.SelectCategory(EditedProduct.Category);
            }

            if (!ProductToEdit.ImageUrl.Equals(EditedProduct.ImageUrl))
            {
                Pages.ProductForm.FillImageUrl(EditedProduct.ImageUrl);
            }

            Pages.ProductForm.ClickSave();

            Driver.WaitFor(() => Pages.AlertPage.IsAlertDisplayed);
            Pages.AlertPage.GetAlertText().Should().Be(Alerts.ProductUpdated.ToDisplayString());

            Driver.WaitFor(() => Driver.GetUrl().Equals(UrlProvider.AdminProductsUrl));
        }
    }
}
