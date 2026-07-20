using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities;

namespace ExpressDesk360.DataAccess.Abstract
{
    public interface I_TaskFileRepository : IRepository<_TaskFile>, IRepositoryAsync<_TaskFile>
    {
    }
}