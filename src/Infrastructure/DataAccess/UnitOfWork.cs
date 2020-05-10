using System;
using WebApi.Infrastructure.DataAccess.Base;
using WebApi.Infrastructure.Db.Context;

namespace WebApi.Infrastructure.DataAccess
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : ApplicationContext
    {
        private readonly IServiceProvider _serviceProvider;

        public TContext Context { get; }

        public UnitOfWork(
            ApplicationContext context
            , IServiceProvider serviceProvider)
        {
            Context = (TContext)context;
            _serviceProvider = serviceProvider;
        }

        public int Commit() => Context.SaveChanges();
        public void Dispose() => Context.Dispose();
        public object GetRepository(Type typeOfIRepository)
            => _serviceProvider.GetService(typeOfIRepository);
        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : Entity
            => (IRepository<TEntity>)_serviceProvider.GetService(typeof(IRepository<TEntity>));
    }
}
