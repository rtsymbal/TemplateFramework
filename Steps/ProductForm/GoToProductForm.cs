using FluentAssertions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TemplateFramework.Base.Extensions.Rest;
using TemplateFramework.Base.Extensions.WebDriver;
using TemplateFramework.Models;
using TemplateFramework.Pipeline;
using TemplateFramework.Providers;

namespace TemplateFramework.Steps.ProductForm
{
    public abstract class GoToEditProductForm : StepComposition, IStep
    {
        [Required]
        public Product Product { get; set; }

        public abstract void Execute();
    }

    public class DefaultGoToEditProductForm : GoToEditProductForm
    {
        public override void Execute()
        {
            Pages.ManageProductsPage.GoToEditProductForm(Product);
            Driver.WaitFor(() => Pages.ProductForm.IsTitleFieldDisplayed);
        }
    }

    public class FastGoToEditProductForm : GoToEditProductForm
    {
        public override void Execute()
        {
            var request = RestFactory.CreateRequest(UrlProvider.Product);
            var response = request.Get<IEnumerable<Product>>().Content;

            var product = response.FirstOrDefault(x => x.Title.Equals(Product.Title));
            product.Should().NotBeNull("product was not found");

            Driver.Open(UrlProvider.EditProduct(product.Id));
        }
    }
}
