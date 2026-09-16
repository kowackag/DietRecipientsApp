namespace Diet.Domain.Common
{
    public class NutritionalValues
    {
        public decimal Calories { get; set; }
        public decimal Proteins { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbohydrates { get; set; }
        public NutritionalValues(decimal calories, decimal proteins, decimal fats, decimal carbohydrates)
        {
            Calories = calories;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }
    }
}
