using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using TemplateFramework.Base.Extensions.WebDriver;
using TemplateFramework.Models;
using TemplateFramework.Pipeline;

namespace TemplateFramework.Steps.ProductForm
{

    public class AssertProductFormIsPrefilled : StepComposition, IStep
    {
        [Required]
        public Product Product { get; set; }

        public void Execute()
        {
            Driver.WaitToCheck(() => Pages.ProductForm.GetTitleFieldValue().Equals(Product.Title)).Should().BeTrue();
            Driver.WaitToCheck(() => Pages.ProductForm.GetPriceFieldValue().Equals(Product.Price)).Should().BeTrue();
            Driver.WaitToCheck(() => Pages.ProductForm.GetSelectedCheckbox().Equals(Product.Category)).Should().BeTrue();
            Driver.WaitToCheck(() => Pages.ProductForm.GetImageUrlFieldValue().Equals(Product.ImageUrl)).Should().BeTrue();
        }
    }
}
