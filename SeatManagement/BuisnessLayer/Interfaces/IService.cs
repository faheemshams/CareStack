using DataAccessLayer.Entities;

namespace BuisnessLayer.Interfaces
{
    public interface IService<Tin, Tout> 
    {
        Tout[] GetAllItems();
        Tout GetItemById(int id);
        Tout AddItem(Tin entity);
        Tout UpdateItem(Tin entity);
        Tout DeleteItem(string name);
    }
}
