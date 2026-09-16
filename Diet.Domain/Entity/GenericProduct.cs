using Diet.Domain.Common;

namespace Diet.Domain.Entity
{
    public class GenericProduct: Product
    {
        public GenericProduct(long id, string name, NutritionalValues nutritionPer100g): base(id, name, nutritionPer100g)
        { }
    }
}
