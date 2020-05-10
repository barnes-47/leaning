using System;
using WebApi.Infrastructure.DataAccess.Base;
using WebApi.Infrastructure.Db.Context;

namespace WebApi.Infrastructure.DataAccess
{
    public interface IUnitOfWork<TContext> : IDisposable
        where TContext : ApplicationContext
    {
        TContext Context { get; }
        int Commit();
        object GetRepository(Type typeOfIRepository);
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
    }
}
