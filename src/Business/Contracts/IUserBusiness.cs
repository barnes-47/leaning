using System;
using System.Collections.Generic;
using WebApi.Infrastructure.Dto;

namespace WebApi.Business.Contracts
{
    public interface IUserBusiness
    {
        void Create(User user);
        void Delete(Guid id);
        User Get(Guid id);
        IEnumerable<User> GetAll();
        void Update(User user);
    }
}
