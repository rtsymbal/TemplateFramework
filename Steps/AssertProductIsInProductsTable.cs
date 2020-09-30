using FluentAssertions;
using TemplateFramework.Base.Extensions.WebDriver;
using TemplateFramework.Models;
using TemplateFramework.Pipeline;
using TemplateFramework.Providers;

namespace TemplateFramework.Steps
{
    public class AssertProductIsInProductsTable : StepComposition, IStep
    {
        public Product Product { get; set; }

        public void Execute()
        {
            Driver.WaitFor(() => Driver.GetUrl().Equals(UrlProvider.AdminProductsUrl));

            Pages.ManageProductsPage.IsProductDisplayed(Product).Should().BeTrue();
        }
    }
}
