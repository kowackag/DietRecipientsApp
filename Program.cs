// See https://aka.ms/new-console-template for more information
using Diet.App.Concrete;
using DietApp.ConsoleUI;
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
            var productMenuController = new ProductMenuController(actionService, productService);

            bool isRunning = true;
            while  (isRunning)
            {
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                ConsoleView.ShowMenuAction(mainMenu);

                var chosenAction = Console.ReadKey();
                Console.WriteLine("");

                switch (chosenAction.KeyChar)
                {
                    case '1':
                        productMenuController.Run();
                        break;
                    case '2':
                        Console.WriteLine("Work in progress...");
                        break;
                    case '3':
                        Console.WriteLine("Exit");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect chosen actions");
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
       
    }
}