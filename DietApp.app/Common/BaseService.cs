using Diet.App.Abstract;
using Diet.Domain.Common;

namespace Diet.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
       protected List<T> Items{ get; set; }

        public BaseService()
        {
            Items = new List<T>();
        }

        public long AddItems(T product)
        {
            Items.Add(product);
            return product.Id;
        }

        public bool RemoveItems(long id)
        {
            int ind = Items.FindIndex(item => item.Id == id);
            if (ind == -1)
            {
                return false;
            }
            else
            {
                Items.RemoveAt(ind);
                return true;
            }
        }

        public IReadOnlyList<T> GetAllItems()
        {
            return Items.AsReadOnly();
        }

        public T? GetItemsById(long id)
        {
            return Items.FirstOrDefault(product => product.Id == id);
        }
    }
}
