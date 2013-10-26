using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Twitter.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All(string includes = null);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        void Detach(T entity);
    }
}
