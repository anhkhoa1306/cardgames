using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CardGames.Application.Persistent
{
    public interface IRepository<T> where T : class
    {
        T GetById(string id);
        List<T> GetAll();
        List<T> Where(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        T Remove(T entity);
        void Attach(T entity);
        bool Any(Expression<Func<T, bool>> predicate);
    }
}