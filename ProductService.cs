namespace DietApp
{
    internal class ProductService
    {
        private List<Product> Products { get; set; }

        public ProductService()
        {
            Products = new List<Product>();
        }

        public void AddNewProduct(long id, string name, decimal calories, decimal proteins, decimal fats, decimal carbohydrates)
        {
            Product newProduct = new Product() { Id = id, Name = name, Calories = calories, Proteins = proteins, Fats = fats, Carbohydrates = carbohydrates };
            Products.Add(newProduct);
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
    }
}
