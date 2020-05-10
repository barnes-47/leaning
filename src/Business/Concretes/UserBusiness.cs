using System;
using System.Collections.Generic;
using WebApi.Business.Contracts;
using WebApi.Infrastructure.DataAccess;
using WebApi.Infrastructure.Db.Context;
using WebApi.Infrastructure.Dto;

namespace WebApi.Business.Concretes
{
    internal class UserBusiness : IUserBusiness
    {
        private readonly IUnitOfWork<ApplicationContext> _uow;

        public UserBusiness(
            IUnitOfWork<ApplicationContext> uow)
        {
            _uow = uow;
        }

        public void Create(User user)
        {
            _uow.GetRepository<User>().Create(user);
            _uow.Context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _uow.GetRepository<User>().Get(id);
            if (user == null)
                return;

            _uow.GetRepository<User>().Delete(user);
            _uow.Context.SaveChanges();
        }

        public User Get(Guid id)
            => _uow.GetRepository<User>().Get(id);

        public IEnumerable<User> GetAll()
            => _uow.GetRepository<User>().GetAll();

        public void Update(User user)
        {
            // Apply validations and business rules
            // before updating the record.

            _uow.GetRepository<User>().Update(user);
            _uow.Commit();
        }
    }
}
