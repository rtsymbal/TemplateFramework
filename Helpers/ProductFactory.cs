using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateFramework.Helpers
{
    public class ProductFactory
    {
        public static Product DefaultTomato()
        {
            return new Product
            {
                Id = 1,
                Title = "Tomato",
                Price = 1.99m,
                Category = Categories.VegetablesAndFruits,
                ImageUrl = "https://cdn.pixabay.com/photo/2019/09/16/14/47/tomato-4481200_960_720.jpg"
            };
        }

        public static Product CustomProduct()
        {
            var uniqueNumber = TestDataGenerator.NewRandomNumber(9);
            var price = Convert.ToDecimal(uniqueNumber) / 100;
            return new Product
            {
                Title = $"Product {uniqueNumber}",
                Price = price,
                Category = EnumHelper.GetRandomValue<Categories>(),
                ImageUrl = "https://p0.pxfuel.com/preview/664/689/308/yellow-gift-box-white.jpg"
            };
        }
    }
}
