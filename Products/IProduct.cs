using DietApp.ProductModels;
//using DietApp.ProductModels;

namespace DietApp.ProductModels
{
    
    internal interface IProduct
    {
        public long Id { get; }
        public string Name { get; set; }
        public NutritionalValues NutritionPer100g { get; set; }
    }
}
