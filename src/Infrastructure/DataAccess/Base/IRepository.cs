using System;
using System.Collections.Generic;

namespace WebApi.Infrastructure.DataAccess.Base
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        void Create(TEntity entity);
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
