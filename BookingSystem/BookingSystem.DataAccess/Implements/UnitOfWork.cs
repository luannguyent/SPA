using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using BookingSystem.Core.Infrastructure;
using BookingSystem.DataAccess.Contracts;
using BookingSystem.DataAccess.UserManager;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookingSystem.DataAccess.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDataContext _dataContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private ObjectContext _objectContext;
        private DbTransaction _transaction;
        private bool _disposed;
        public UnitOfWork(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                try
                {
                    if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                    {
                        _objectContext.Connection.Close();
                    }
                }
                catch (ObjectDisposedException)
                {
                }

                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                    _dataContext = null;
                }
            }
            _disposed = true;
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState
        {
            if (_repositories.Keys.Contains(typeof (TEntity)))
            {
                return _repositories[typeof (TEntity)] as IRepository<TEntity>;
            }
            var type = typeof(TEntity);
            var repositoryType = typeof(Repository<>);
            var repositoryInstance =
                   Activator.CreateInstance(repositoryType
                           .MakeGenericType(typeof(TEntity)), _dataContext);
            _repositories.Add(typeof(TEntity), repositoryInstance);
            return (IRepository<TEntity>)_repositories[type];
        }

        public void BeginTransaction(System.Data.IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            _objectContext = ((IObjectContextAdapter)_dataContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }

            _transaction = _objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            _transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _dataContext.SyncObjectsStatePostCommit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
