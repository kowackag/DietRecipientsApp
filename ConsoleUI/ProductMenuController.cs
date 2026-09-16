using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diet.App.Concrete;

namespace DietApp.ConsoleUI
{
    internal class ProductMenuController
    {
        private readonly MenuActionService _actionService;
        private readonly ProductService _productService;

        public ProductMenuController(MenuActionService actionService, ProductService productService)
        {
            _actionService = actionService;
            _productService = productService;
        }

        public void Run()
        {
            var subMenu = _actionService.GetMenuActionsByMenuName("SubMenu");
            bool isSubMenuRunning = true;
            while (isSubMenuRunning)
            {
                ConsoleView.ShowMenuAction(subMenu);
                var chosenAction = Console.ReadKey();
                Console.WriteLine("");
                switch (chosenAction.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Write product name");
                        string name = ConsoleInputService.GetUserInputString("name");
                        Console.WriteLine("Write calories per 100 gram");
                        decimal calories = ConsoleInputService.GetUserInputNumber<decimal>("calories");
                        Console.WriteLine("Write proteins per 100 gram");
                        decimal proteins = ConsoleInputService.GetUserInputNumber<decimal>("proteins");
                        Console.WriteLine("Write fats per 100 gram");
                        decimal fats = ConsoleInputService.GetUserInputNumber<decimal>("fats");
                        Console.WriteLine("Write carbohydrates per 100 gram");
                        decimal carbohydrates = ConsoleInputService.GetUserInputNumber<decimal>("carbohydrates");

                        Console.WriteLine("Is it a branded product? (if branded type 'yes')");
                        string isBranded = ConsoleInputService.GetUserInputString("yes or no");
                        if (isBranded.ToLower() == "yes")
                        {
                            Console.WriteLine("Write brand name");
                            string brand = ConsoleInputService.GetUserInputString("brand");
                            Console.WriteLine("Write barcode (optional)");
                            string? barcode = ConsoleInputService.GetUserInputString("barcode", true);
                            Console.WriteLine("Write description (optional)");
                            string? description = ConsoleInputService.GetUserInputString("description", true);
                            _productService.AddBrandedProduct(name, calories, proteins, fats, carbohydrates, brand, barcode, description);
                        }
                        else
                        {
                            _productService.AddGenericProduct(name, calories, proteins, fats, carbohydrates);
                        }

                        break;
                    case '2':
                        Console.WriteLine("Write id to remove");
                        long idToRemove = ConsoleInputService.GetUserInputNumber<long>("id");
                        bool isToRemove = _productService.RemoveProduct(idToRemove);
                            
                        if (!isToRemove)
                        {
                            Console.WriteLine("Incorrect id. Choose one from below: ");
                            ConsoleView.ShowProducts(_productService.GetAllProducts());
                        }
                        else
                        {
                            Console.WriteLine("Product was successfully removed ");
                        }
                        break;
                    case '3':
                        ConsoleView.ShowProducts(_productService.GetAllProducts());
                        break;
                    case '4':
                        Console.WriteLine("Go back");
                        isSubMenuRunning = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect chosen actions");
                        break;
                }
            }
        }
    }
}
