using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementations
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext appDbContext;
        public SqlRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public T AddItem(T entity) 
        {
            var result = appDbContext.Set<T>().Add(entity);
            appDbContext.SaveChanges();
            return result.Entity;
        }

        public void DeleteItem(int id)
        {
            T Item = GetItemById(id);

            if(Item != null) 
            {
                appDbContext.Set<T>().Remove(Item);
                appDbContext.SaveChanges();
            }
        }

        public IQueryable<T> GetAllItems()
        {
            return appDbContext.Set<T>();
        }

        public T GetItemById(int? id)
        {
            return appDbContext.Set<T>().Find(id);
        }

        public void UpdateItem(T entity)
        {
            appDbContext.Entry(entity).State = EntityState.Modified;  
            appDbContext.SaveChanges(); 
        }
    }
}
