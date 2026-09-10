using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietApp.ProductModels;

namespace DietApp.ProductModels
{
    public abstract class Product : IProduct
    {
        public long Id { get; }

        public string Name { get; set; }
        public NutritionalValues NutritionPer100g { get; set; }

        protected Product(long id, string name, NutritionalValues nutritionPer100g)
        {
            Id = id;
            Name = name;
            NutritionPer100g = nutritionPer100g;
        }
    }
}
