namespace DietApp
{
    internal class MenuActionService
    {
        private List<MenuAction> menuActions;

        public MenuActionService()
        {
            menuActions = new List<MenuAction>();
        }
        public void AddNewAction (int id, string actionName, string menuName)
        {
            MenuAction menuAction = new MenuAction() { Id = id, ActionName = actionName, MenuName = menuName };
            menuActions.Add(menuAction);
        }

        public List<MenuAction> GetMenuActionsByMenuName (string menuName)
        {
           List<MenuAction> actions = menuActions.FindAll(action => action.MenuName == menuName);
           return actions;
        }
    }
}
 