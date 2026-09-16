//using DietApp.ProductModels;

namespace Diet.Domain.Common
{
    
    internal interface IProduct
    {
        public long Id { get; }
        public string Name { get; set; }
        public NutritionalValues NutritionPer100g { get; set; }
    }
}
