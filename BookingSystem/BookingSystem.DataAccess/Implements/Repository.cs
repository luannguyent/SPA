using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Core.Infrastructure;
using BookingSystem.DataAccess.Contracts;

namespace BookingSystem.DataAccess.Implements
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class ,IObjectState
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly IDataContext _dataContext;
        public Repository(IDataContext dataContext)
        {
            _dataContext = dataContext;
            var dbContext = dataContext as DbContext;
            if (dbContext != null) _dbSet = dbContext.Set<TEntity>();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            return _dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        public void Insert(TEntity entity)
        {
            entity.ObjectState = ObjectState.Added;
            _dbSet.Attach(entity);
            _dataContext.SyncObjectState(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }
        public void Update(TEntity entity)
        {
            entity.ObjectState = ObjectState.Modified;
            _dbSet.Attach(entity);
            _dataContext.SyncObjectState(entity);
        }

        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            entity.ObjectState = ObjectState.Deleted;
            _dbSet.Attach(entity);
            _dataContext.SyncObjectState(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).FirstOrDefault();
        }

        public IQueryable<TEntity> Gets(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
