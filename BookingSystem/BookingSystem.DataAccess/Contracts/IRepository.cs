using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Core.Infrastructure;

namespace BookingSystem.DataAccess.Contracts
{
    public interface IRepository<TEntity> where TEntity : class ,IObjectState
    {
        TEntity Find(params object[] keyValues);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);

        IQueryable<TEntity> GetAll();

        TEntity Get(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> Gets(Expression<Func<TEntity, bool>> expression);
    }
}
