using FluentAssertions;
using TemplateFramework.Pipeline;

namespace TemplateFramework.Steps.ProductForm
{
    public class AssertProductFormFieldsAreDisplayed : StepComposition, IStep
    {
        public void Execute()
        {
            Pages.ProductForm.IsTitleFieldDisplayed.Should().BeTrue(FailMessage("title"));
            Pages.ProductForm.IsPriceFieldDisplayed.Should().BeTrue(FailMessage("price"));
            Pages.ProductForm.AreCategoryCheckboxesDisplayed.Should().BeTrue(FailMessage("categories"));
            Pages.ProductForm.IsImageUrlFieldDisplayed.Should().BeTrue(FailMessage("image url"));
        }

        private static string FailMessage(string field) => $"{field} should be displayed.";
    }
}
