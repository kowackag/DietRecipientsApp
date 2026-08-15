namespace DietApp
{
    internal class ProductService
    {
        public List<Product> Products { get; set; }

        public ProductService()
        {
            Products = new List<Product>();
        }

        public void AddNewProduct(long id, string name, decimal calories, decimal proteins, decimal fats, decimal carbohydrates)
        {
            Product newProduct = new Product() { Id = id, Name = name, Calories = calories, Proteins = proteins, Fats = fats, Carbohydrates = carbohydrates };
            Products.Add(newProduct);
        }

        public void RemoveProduct(long id)
        {
            int ind = Products.FindIndex(item => item.Id == id);
            if (ind == -1)
            {
                Console.WriteLine("Incorect id. Choose one from below: ");
                ShowAllProducts();
            }
            else
            {
                Products.RemoveAt(ind);
                Console.WriteLine("Product was succesfully removed ");
            }
        }

        public void ShowAllProducts()
        {
            if (Products.Count == 0)
            {
                Console.WriteLine("The list is empty");
                return;
            }
            Console.WriteLine(
                $"{"id",-20}" +
                $"{"Name",24}" +
                $"{"Calories",10}" +
                $"{"Proteins",10}" +
                $"{"Fats",10}" +
                $"{"Carbohydrates",18}"
            );
            foreach (var product in Products)
            {

                Console.WriteLine(
                    $"{product.Id,-20}" + 
                    $"{product.Name,24}"+
                    $"{product.Calories,10}"+
                    $"{product.Proteins,10}"+
                    $"{product.Fats,10}"+
                    $"{product.Carbohydrates,18}");
            }
        }
    }
}
