using Diet.Domain.Common;

namespace Diet.Domain.Entity
{
    public class BrandedProduct : Product
    {
        public string Brand { get; set; }
        public string? Barcode { get; set; }
        public string? Description { get; set; }

        public BrandedProduct(long id, string name, NutritionalValues nutritionPer100g, string brand, string? barcode, string? description)
            : base(id, name, nutritionPer100g)
        {
            Brand = brand;
            Barcode = barcode;
            Description = description;
        }
    }
}
