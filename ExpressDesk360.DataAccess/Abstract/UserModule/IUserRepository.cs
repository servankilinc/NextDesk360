using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.UserModule;

namespace ExpressDesk360.DataAccess.Abstract.UserModule
{
    public interface IUserRepository : IRepository<User>, IRepositoryAsync<User>
    {
    }
}