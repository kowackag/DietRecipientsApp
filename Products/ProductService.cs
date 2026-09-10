using DietApp.ProductModels;
using DietApp.ProductsModel;

namespace DietApp.ProductModel
{
    internal class ProductService
    {
        private List<Product> Products { get; set; }

        public ProductService()
        {
            Products = new List<Product>();
        }

        private long AddProduct (Product product)
        {
            Products.Add(product);
            return product.Id;
        }

        public long AddGenericProduct(string name, decimal calories, decimal proteins, decimal fats, decimal carbohydrates)
        {
            long id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var nutrition = new NutritionalValues(calories, proteins, fats, carbohydrates);
            return AddProduct(new GenericProduct(id, name, nutrition));
        }

        public long AddBrandedProduct(string name, decimal calories, decimal proteins, decimal fats, decimal carbohydrates,string brand, string? barcode, string? description)
        {
            long id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var nutrition = new NutritionalValues(calories, proteins, fats, carbohydrates);
            return AddProduct( new BrandedProduct(id, name, nutrition, brand, barcode, description));
        }

        public bool RemoveProduct(long id)
        {
            int ind = Products.FindIndex(item => item.Id == id);
            if (ind == -1)
            {
                return false;
            }
            else
            {
                Products.RemoveAt(ind);
                return true;
            }
        }

        public IReadOnlyList<Product> GetAllProducts()
        {
            return Products.AsReadOnly();
        }

        public Product? GetProductsById(long id)
        {
            return Products.FirstOrDefault(product => product.Id == id);
        }
    }
}
