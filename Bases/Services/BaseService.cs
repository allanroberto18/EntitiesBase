using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Bases.Context;
using Entities.Bases.Repositories;

namespace Entities.Bases.Services
{
    public class BaseService<T> : IDisposable, IBaseService<T> where T: class
    {
        IUnitOfWork unitOfWork = new EntityContext();
        private IBaseRepository<T> _repository;

        public BaseService()
        {
            _repository = new BaseRepository<T>(unitOfWork);
        } 
         
        public T Find(int id)
        {
            return _repository.Find(id);
        }

        public ICollection<T> Consult()
        {
            return List().ToList();
        }

        public virtual ICollection<T> Consult(string param, string field)
        {
            return Consult();
        }

        public IQueryable<T> List()
        {
            return _repository.List();
        }

        public void Add(T item)
        {
            _repository.Add(item);

            unitOfWork.Save();
        }

        public void Remove(T item)
        {
            _repository.Remove(item);

            unitOfWork.Save();
        }

        public void Edit(T item)
        {
            _repository.Edit(item);

            unitOfWork.Save();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}