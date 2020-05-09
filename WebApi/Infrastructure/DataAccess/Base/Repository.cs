using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Infrastructure.Db.Context;

namespace WebApi.Infrastructure.DataAccess.Base
{
    internal class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly IUnitOfWork<ApplicationContext> _uow;

        public Repository(IUnitOfWork<ApplicationContext> uow)
        {
            _uow = uow;
        }

        public void Create(TEntity entity)
        {
            _uow.Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            var existing = _uow.Context.Set<TEntity>().Find(entity);
            if (existing == null)
                return;

            _uow.Context.Set<TEntity>().Remove(entity);
        }

        public TEntity Get(Guid id)
            => _uow.Context.Set<TEntity>().FirstOrDefault(_ => _.Id == id);

        public IEnumerable<TEntity> GetAll()
            => _uow.Context.Set<TEntity>();

        public void Update(TEntity entity)
        {
            _uow.Context.Entry(entity).State = EntityState.Modified;
            _uow.Context.Set<TEntity>().Attach(entity);
        }
    }
}
