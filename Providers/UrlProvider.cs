namespace TemplateFramework.Providers
{
    public class UrlProvider
    {
        public static string BaseUrl => TestConfiguration.EnvSettings.Url;
        private static string Url(string path) => $"{BaseUrl}/{path}";

        public static string Product => Url("product");
        public static string AdminProductsUrl => Url("admin/products");
        public static string NewProductFormUrl => Url("admin/products/new");
        public static string Authentication => Url("authentication");

        public static string AddCategory(int productId, int categoryId) => Url($"productcategory/{productId}/{categoryId}");
        public static string EditProduct(int productId) => Url($"admin/products/{productId}");
    }
}
