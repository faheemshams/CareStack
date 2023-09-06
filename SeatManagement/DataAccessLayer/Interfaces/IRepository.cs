using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAllItems();
        T GetItemById(int? id);
        T AddItem(T entity);
        void UpdateItem (T entity); 
        void DeleteItem (int id);
    }
}
