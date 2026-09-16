using Diet.App.Common;
using Diet.Domain.Entity;
using Diet.Domain.Common;

namespace Diet.App.Concrete
{
    public class ProductService : BaseService<Product>
    {
        public long AddGenericProduct(string name, decimal calories, decimal proteins, decimal fats, decimal carbohydrates)
        {
            long id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var nutrition = new NutritionalValues(calories, proteins, fats, carbohydrates);
            return AddItems(new GenericProduct(id, name, nutrition));
        }

        public long AddBrandedProduct(string name, decimal calories, decimal proteins, decimal fats, decimal carbohydrates,string brand, string? barcode, string? description)
        {
            long id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var nutrition = new NutritionalValues(calories, proteins, fats, carbohydrates);
            return AddItems( new BrandedProduct(id, name, nutrition, brand, barcode, description));
        }

        public bool RemoveProduct(long id)
        {
          return RemoveItems(id);
        }

        public IReadOnlyList<Product> GetAllProducts()
        {
            return GetAllItems();
        }

        public Product? GetProductsById(long id)
        {
            return GetItemsById(id);
        }
    }
}
