namespace TemplateFramework.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Categories Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
