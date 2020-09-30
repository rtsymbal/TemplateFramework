using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateFramework.Base.Dtos
{

    public class CreateProductDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
