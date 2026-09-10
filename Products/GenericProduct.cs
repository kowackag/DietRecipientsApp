using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietApp.ProductModels;

namespace DietApp.ProductsModel
{
    internal class GenericProduct: Product
    {
        public GenericProduct(long id, string name, NutritionalValues nutritionPer100g): base(id, name, nutritionPer100g)
        { }
    }
}
