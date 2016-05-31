using System.Collections.Generic;
using System.Linq;

namespace Entities.Bases.Services
{
    public interface IBaseService<T> where T : class
    {
        T Find(int id);

        IQueryable<T> List();

        ICollection<T> Consult();

        ICollection<T> Consult(string param, string field);

        void Add(T item);

        void Remove(T item);

        void Edit(T item);
    }
}