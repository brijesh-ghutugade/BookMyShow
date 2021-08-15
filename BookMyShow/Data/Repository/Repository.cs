using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookMyShow.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbContext context;
        public DbSet<T> dbset;
        public Repository(DbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }


        public IQueryable<T> GetAll()
        {
            return dbset;
        }

        public void Insert(T entity)
        {
            dbset.Add(entity);
        }


        public void Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }


        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbset.Where(predicate);
            return query;
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public T GetWithChildren(int id, string child)
        {
            var model = dbset.Find(id);
            context.Entry(model).Collection(child).Load();
            return model;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, IList<string> includes)
        {
            IQueryable<T> query = dbset.Where(predicate).AsQueryable();

            foreach (var include in includes) {
                query = query.Include(include);
            }
                

            return query;
        }
    }
}
