using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MusicLibrary.Services.Models
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        public EfRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("DbContext can't be null");
            }

            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }

        public T Get(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(item);
            }

            this.Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Remove(entity);
            }

            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = this.Get(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Update(int id, T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
            else
            {
                this.DbSet.Attach(item);
            }
            
            this.Context.SaveChanges();
        }
    }
}