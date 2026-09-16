using Diet.Domain.Common;

namespace Diet.Domain.Entity
{
    public abstract class Product : BaseEntity, IProduct
    {
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
