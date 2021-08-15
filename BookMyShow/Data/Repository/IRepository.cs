using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookMyShow.Data.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, IList<string> includes);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        IQueryable<T> GetAll();

        void Edit(T entity);

        void Insert(T entity);

        void Delete(T entity);

        T GetWithChildren(int id, string child);
    }
}
