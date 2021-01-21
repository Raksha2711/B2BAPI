using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace B2b.BusinessService
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        TEntity Get(int id);
        TEntity Create(TEntity entity);

        TEntity Update(int id, TEntity entity);
        int Delete(int id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);
    }
}
