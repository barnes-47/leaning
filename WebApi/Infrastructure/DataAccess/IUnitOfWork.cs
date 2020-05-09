using System;
using WebApi.Infrastructure.DataAccess.Base;
using WebApi.Infrastructure.Db.Context;

namespace WebApi.Infrastructure.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
        int SaveChanges();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork
        where TContext : ApplicationContext
    {
        TContext Context { get; }
    }
}
