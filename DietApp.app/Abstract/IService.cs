namespace Diet.App.Abstract
{
    public interface IService<T>
    {
        IReadOnlyList<T> GetAllItems();
        long AddItems(T item);
        bool RemoveItems(long id);
        T? GetItemsById(long id);
    }
}
