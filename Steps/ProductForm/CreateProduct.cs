using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentAssertions;
using Ninject;
using TemplateFramework.Base.Dtos;
using TemplateFramework.Base.Enums;
using TemplateFramework.Base.Extensions.Rest;
using TemplateFramework.Base.Extensions.WebDriver;
using TemplateFramework.Models;
using TemplateFramework.Pipeline;
using TemplateFramework.Providers;

namespace TemplateFramework.Steps.ProductForm
{
    public abstract class CreateProduct : StepComposition, IStep
    {
        [Required]
        public Product Product { get; set; }

        public abstract void Execute();
    }

    public class DefaultCreateProduct : CreateProduct
    {
        public override void Execute()
        {
            Pages.ProductForm.FillForm(Product);
            Pages.ProductForm.ClickSave();

            Driver.WaitFor(() => Pages.AlertPage.IsAlertDisplayed);
            Pages.AlertPage.GetAlertText().Should().Be(Alerts.ProductCreated.ToDisplayString());

            Driver.WaitFor(() => Driver.GetUrl().Equals(UrlProvider.AdminProductsUrl));
        }
    }

    public class FastCreateProduct : CreateProduct
    {
        [Inject]
        public User User { get; set; }

        public override void Execute()
        {
            var productId = GetProductIdFromCreateProduct();
            AddCategoryToProduct(productId);

            Driver.Open(UrlProvider.AdminProductsUrl);
        }

        private int GetProductIdFromCreateProduct()
        {
            var productDto = new CreateProductDto
            {
                Title = Product.Title,
                Price = Product.Price,
                ImageUrl = Product.ImageUrl
            };

            var request = RestFactory.CreateRequest(UrlProvider.Product);

            request.AddJsonBody(productDto);
            request.WithAuthorization(User.Token);

            var responseContent = request.Post<dynamic>().Content;

            return (int)responseContent.id;
        }

        private void AddCategoryToProduct(int productId)
        {
            var request = RestFactory.CreateRequest(UrlProvider.AddCategory(productId, (int)Product.Category));
            request.WithAuthorization(User.Token);
            request.Put();
        }
    }
}
