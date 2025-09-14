using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    internal class ProductService
    {
        public List<Product> Products { get; set; }

        public ProductService()
        {
            Products = new List<Product>();
        }

        public void AddNewProduct(int id, string name, string measure)
        {
            Product newProduct = new Product() { Id = id, Name = name, Measure = measure };
            Products.Add(newProduct);
        }

        public void RemoveProduct(int id)
        {
            int ind = Products.FindIndex(item => item.Id == id);
            Products.RemoveAt(ind);
        }
        public static void ShowAllProducts(List<Product> products)
        {
            for (int i =0; i<products.Count;i++)
            {
                Console.WriteLine($"{products[i].Id}. {products[i].Name}, measerue: {products[i].Measure}");
            }
        }
    }
}
