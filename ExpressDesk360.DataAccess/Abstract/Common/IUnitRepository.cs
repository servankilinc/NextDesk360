using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.Common;

namespace ExpressDesk360.DataAccess.Abstract.Common
{
    public interface IUnitRepository : IRepository<Unit>, IRepositoryAsync<Unit>
    {
    }
}