using DataAccessLayer.Entities;

namespace BuisnessLayer.ServiceInterfaces
{
    public interface IService<T> where T : class
    {
        T[] GetAllItems();
        T GetItemById(int id);
        T AddItem(T entity);
        T UpdateItem(T entity);
        T DeleteItem(int id);
    }
}
