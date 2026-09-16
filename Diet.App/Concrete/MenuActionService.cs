using Diet.App.Common;
using Diet.Domain.Entity;

namespace Diet.App.Concrete
{
    public class MenuActionService:BaseService<MenuAction>
    {
        public void AddNewAction (int id, string actionName, string menuName)
        {
            MenuAction menuAction = new MenuAction() { Id = id, ActionName = actionName, MenuName = menuName };
            AddItems(menuAction);
        }

        public List<MenuAction> GetMenuActionsByMenuName (string menuName)
        {
           List<MenuAction> actions = Items.FindAll(action => action.MenuName == menuName);
           return actions;
        }
    }
}
