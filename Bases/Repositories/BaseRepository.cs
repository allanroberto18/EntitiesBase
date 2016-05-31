using System;
using System.Data.Entity;
using System.Linq;
using Entities.Bases.Context;


namespace Entities.Bases.Repositories
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private EntityContext _connection;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentException("unitOfWork");
            _connection = unitOfWork as EntityContext;
        } 

        public T Find(int id)
        {
            return _connection.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            return _connection.Set<T>();
        }

        public void Add(T item)
        {
            _connection.Set<T>().Add(item);
        }

        public void Remove(T item)
        {
            _connection.Set<T>().Remove(item);
        }

        public void Edit(T item)
        {
            _connection.Entry(item).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}