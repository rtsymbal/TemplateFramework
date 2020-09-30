using TemplateFramework.Base.Extensions.WebDriver;
using TemplateFramework.Pipeline;
using TemplateFramework.Providers;

namespace TemplateFramework.Steps
{
    public abstract class GoToNewProductForm : StepComposition, IStep
    {
        public abstract void Execute();
    }

    public class DefaultGoToNewProductForm : GoToNewProductForm
    {
        public override void Execute()
        {
            if (!Driver.GetUrl().Equals(UrlProvider.AdminProductsUrl))
            {
                Pages.NavigationPanel.GoToManageProducts();
            }
            Pages.ManageProductsPage.GoToNewProductForm();

            Driver.WaitFor(() => Driver.GetUrl().Equals(UrlProvider.NewProductFormUrl));
        }
    }

    public class FastGoToNewProductForm : GoToNewProductForm
    {
        public override void Execute()
        {
            Driver.Open(UrlProvider.NewProductFormUrl);
        }
    }
}
