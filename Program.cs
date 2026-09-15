// See https://aka.ms/new-console-template for more information
using System.Numerics;
using DietApp.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to DietApp");

            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);

            ProductService productService = new ProductService();

            bool isRunning = true;
            while  (isRunning)
            {
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                ShowMenuAction(mainMenu);

                var chosenAction = Console.ReadKey();
                Console.WriteLine("");

                switch (chosenAction.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Work in progress...");

                        break;
                    case '2':
                        var subMenu = actionService.GetMenuActionsByMenuName("SubMenu");
                        bool isSubMenuRunning = true;
                        while (isSubMenuRunning)
                        {
                            ShowMenuAction(subMenu);
                            chosenAction = Console.ReadKey();
                            Console.WriteLine("");
                            switch (chosenAction.KeyChar)
                            {
                                case '1':
                                    Console.WriteLine("Write product name");
                                    string name = GetUserInputString("name");
                                    Console.WriteLine("Write calories per 100 gram");
                                    decimal calories = GetUserInputNumber<decimal>("calories");
                                    Console.WriteLine("Write proteins per 100 gram");
                                    decimal proteins = GetUserInputNumber<decimal>("proteins");
                                    Console.WriteLine("Write fats per 100 gram");
                                    decimal fats = GetUserInputNumber<decimal>("fats");
                                    Console.WriteLine("Write carbohydrates per 100 gram");
                                    decimal carbohydrates = GetUserInputNumber<decimal>("carbohydrates");

                                    Console.WriteLine("Is it a branded product? (if branded type 'yes')");
                                    string isBranded = GetUserInputString("yes or no");
                                    if (isBranded.ToLower() == "yes")
                                    {
                                        Console.WriteLine("Write brand name");
                                        string brand = GetUserInputString("brand");
                                        Console.WriteLine("Write barcode (optional)");
                                        string? barcode = GetUserInputString("barcode", true);
                                        Console.WriteLine("Write description (optional)");
                                        string? description = GetUserInputString("description", true);
                                        productService.AddBrandedProduct(name, calories, proteins, fats, carbohydrates, brand, barcode, description);
                                    }
                                    else
                                    {
                                        productService.AddGenericProduct(name, calories, proteins, fats, carbohydrates);
                                    }

                                    break;
                                case '2':
                                    Console.WriteLine("Write id to remove");
                                    long idToRemove = GetUserInputNumber<long>("id");
                                    bool isToRemove = productService.RemoveProduct(idToRemove);

                                    if (!isToRemove)
                                    {
                                        Console.WriteLine("Incorect id. Choose one from below: ");
                                        ShowProducts(productService.GetAllProducts());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Product was succesfully removed ");
                                    }
                                    break;
                                case '3':
                                    ShowProducts(productService.GetAllProducts());
                                    break;
                                case '4':
                                    Console.WriteLine("Go back");
                                    isSubMenuRunning = false;
                                    break;
                                default:
                                    Console.WriteLine("Incorect chosen actions");
                                    break;
                            }
                        }
                        break;
                    case '3':
                        Console.WriteLine("Exit");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Incorect chosen actions");
                        break;
                }
            }

        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Go to recipes", "Main");
            actionService.AddNewAction(2, "Go to products", "Main");
            actionService.AddNewAction(3, "Exit", "Main");

            actionService.AddNewAction(1, "Add item", "SubMenu");
            actionService.AddNewAction(2, "Remove item", "SubMenu");
            actionService.AddNewAction(3, "Show list", "SubMenu");
            actionService.AddNewAction(4, "Go back", "SubMenu");


            return actionService;
        }
        public static void ShowMenuAction(List<MenuAction> actions)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"{actions[i].Id}. {actions[i].ActionName}");
            }
        }

        internal static string GetUserInputString(string name, bool isOptional = false)
        {
            string? userInput = Console.ReadLine();
            bool isCorrectInput = userInput != null && userInput.Length > 0;
            while (!isCorrectInput && !isOptional)
            {
                Console.WriteLine($"Incorect {name}, try again");
                userInput = Console.ReadLine();
                isCorrectInput = userInput != null && userInput.Length > 0;
            }
            return userInput ?? string.Empty;
        }

        internal static T GetUserInputNumber<T>(string name) where T: INumber<T>
        {
            string? userInput = Console.ReadLine();
            bool isCorrectInput = T.TryParse(userInput, null, out T number);
                 
            while (!isCorrectInput)
            {
                Console.WriteLine($"Incorrect {name}, try again");
                userInput = Console.ReadLine();
                isCorrectInput = T.TryParse(userInput, null, out number);
            }
            return number;
        }

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
    }
}