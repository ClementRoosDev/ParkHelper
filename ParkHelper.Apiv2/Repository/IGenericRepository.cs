using System.Collections.Generic;

namespace ParkHelper.Apiv2.Repository
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
