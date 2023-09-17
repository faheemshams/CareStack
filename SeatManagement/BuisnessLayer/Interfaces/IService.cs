namespace BuisnessLayer.Interfaces
{
    public interface IService<T> 
    {
        T[] GetAllItems();
        T GetItemById(int id);
        void AddItem(T entity);
        void UpdateItem(T entity);
        void DeleteItem(string name);
    }
}
