using System.Linq;
using WebApi.Infrastructure.DataAccess.Base;
using WebApi.Infrastructure.DataAccess.Contracts;
using WebApi.Infrastructure.Db.Context;
using WebApi.Infrastructure.Dto;

namespace WebApi.Infrastructure.DataAccess.Concretes
{
    internal class UserRepository :
        Repository<User>
        , IUserRepository
    {
        public UserRepository(IUnitOfWork<ApplicationContext> uow)
            : base(uow)
        {

        }

        public bool IsFirstnameExists(string firstname)
        {
            var user = _uow.Context.Set<User>().FirstOrDefault(_ => _.Firstname == firstname);
            return user != null;
        }
    }
}
