using System.Collections.Generic;

namespace ParkHelper.OData.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int id);
    }
}
