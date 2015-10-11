using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Data.Repositories
{
    public class Repository<T>
       : IRepository<T> where T : class
    {
        public Repository(TwitterEntity context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected TwitterEntity Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.DbSet.Where(expression).AsQueryable();
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public T Add(T entity)
        {
            this.DbSet.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            this.DbSet.AddOrUpdate(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            this.DbSet.Remove(entity);
        }
    }
}
