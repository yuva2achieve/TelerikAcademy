using System;
using System.Linq;
using System.Linq.Expressions;

namespace StudentSystem.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Get(int id);

        void Add(T item);

        void Delete(int id);

        void Update(int id, T item);
    }
}
