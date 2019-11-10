using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CardGames.Application.Persistent;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CardGames.Persistent
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IdentityDbContext Context;

        protected Repository(IdentityDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public T GetById(string id)
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public List<T> Where(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T Add(T entity)
        {
            Context.Set<T>().Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public T Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            return entity;
        }

        public void Attach(T entity)
        {
            Context.Set<T>().Attach(entity);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Any(predicate);
        }
    }
}
