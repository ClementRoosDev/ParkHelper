using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ParkHelper.Data;

namespace ParkHelper.OData.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly ParcHelperEntities _context;
        protected readonly DbSet<T> Table; 

        public GenericRepository()
        {
            _context = new ParcHelperEntities();
            Table = _context.Set<T>();
        }
        public List<T> List => Table.ToList();

        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public T FindById(int id)
        {
           return Table.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}