// See https://aka.ms/new-console-template for more information
namespace DietApp
{
    class Program
    {
        static void Main(string[] args)



        {
            Console.WriteLine("Welcome to DietApp");

            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);

            var mainMenu = actionService.GetMenuActionsByMenuName("Main");
            ShowMenuAction(mainMenu);

            var chosenAction = Console.ReadKey();
            var subMenu = actionService.GetMenuActionsByMenuName("Sub menu");
            switch (chosenAction.KeyChar)
            {
                case '1':
                    ShowMenuAction(subMenu);
                    break;
                case '2':
                    ShowMenuAction(subMenu);
                    break;
                default:
                    Console.WriteLine("Incorect chosen actions");
                    break;
            }
            ShowMenuAction(subMenu);
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Go to recipes", "Main");
            actionService.AddNewAction(2, "Go to products", "Main");

            actionService.AddNewAction(1, "Add item", "Sub menu");
            actionService.AddNewAction(2, "Remove item", "Sub menu");
            actionService.AddNewAction(3, "Show list", "Sub menu");

            return actionService;
        }

        public static void ShowMenuAction(List<MenuAction> actions)
        {
            for(int i=0; i<actions.Count; i++)
            {
                Console.WriteLine($"{actions[i].Id}. {actions[i].ActionName}");
            }
        }
    }
}