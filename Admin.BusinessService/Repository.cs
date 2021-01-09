using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Db;
using System.Collections.Generic;

namespace Admin.BusinessService
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        internal readonly B2bDbContext _dbContext;
        public Repository()
        {
            // _dbContext = Query.Db.QueryDbContextFactory.GetInstance("QueryDbContext");
            _dbContext = new B2bDbContext();
        }
        //public Repository(string cn)
        //{
        //    //_dbContext = Query.Db.QueryDbContextFactory.GetInstance(cn);
        //    _dbContext = Query.Db.QueryDbContextFactory.GetInstance(cn);
        //}
        //public Repository(B2bDbContext dbContext)
        //{
        //    this._dbContext = dbContext;
        //}

        public virtual IQueryable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
        public void AttachedEntity(TEntity entity)
        {
            var entry = _dbContext.Set<TEntity>().Add(entity);

        }
        public virtual TEntity Create(TEntity entity)
        {
            AttachedEntity(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public async Task<IEnumerable<TEntity>> CreateBatch(IEnumerable<TEntity> tList)
        {
            foreach (var t in tList)
            {
                AttachedEntity(t);
            }
            await _dbContext.SaveChangesAsync();
            return tList;
        }

        public virtual TEntity Update(int id, TEntity entity)
        {
            if (entity == null)
                return null;

            var entry = _dbContext.Update(entity);
            entry.State = EntityState.Modified;


            _dbContext.SaveChanges();
            //TEntity existing = _dbContext.Set<TEntity>().Find(id);
            
            return entity;
        }

        public virtual int Delete(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().Where(predicate);
            return query;
        }

        public int Count()
        {
            return _dbContext.Set<TEntity>().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).Count();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
