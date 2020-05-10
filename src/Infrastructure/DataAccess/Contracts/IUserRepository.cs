using WebApi.Infrastructure.DataAccess.Base;
using WebApi.Infrastructure.Dto;

namespace WebApi.Infrastructure.DataAccess.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsFirstnameExists(string firstname);
    }
}
