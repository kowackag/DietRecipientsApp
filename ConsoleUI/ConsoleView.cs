using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diet.Domain.Entity;

namespace DietApp.ConsoleUI
{
    internal class ConsoleView
    {
        internal static void ShowProducts(IReadOnlyList<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("The list is empty");
                return;
            }
            Console.WriteLine(
                $"{"id",-12}" +
                $"{"Name",18}" +
                $"{"Calories 100g",18}" +
                $"{"Proteins 100g",18}" +
                $"{"Fats 100g",18}" +
                $"{"Carbohydrates 100g",22}" +
                $"{"Brand",16}" +
                $"{"Barcode",16}"
            );
            foreach (var product in products)
            {
                var branded = product as BrandedProduct;
                Console.WriteLine(
                    $"{product.Id,-12}" +
                    $"{product.Name,18}" +
                    $"{product.NutritionPer100g.Calories,18}" +
                    $"{product.NutritionPer100g.Proteins,18}" +
                    $"{product.NutritionPer100g.Fats,18}" +
                    $"{product.NutritionPer100g.Carbohydrates,22}" +
                    $"{branded?.Brand ?? "---",16}" +
                    $"{branded?.Barcode ?? "---",16}"
                    );
            }
        }

        internal static void ShowMenuAction(List<MenuAction> actions)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"{actions[i].Id}. {actions[i].ActionName}");
            }
        }
    }
}
