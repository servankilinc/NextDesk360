using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.UserModule;
using ExpressDesk360.DataAccess.Abstract.UserModule;

namespace ExpressDesk360.DataAccess.Concrete.UserModule
{
    public class UserRepository : RepositoryBase<User, AppDbContext>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}