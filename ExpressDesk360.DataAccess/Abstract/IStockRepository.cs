using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities;

namespace ExpressDesk360.DataAccess.Abstract
{
    public interface IStockRepository : IRepository<Stock>, IRepositoryAsync<Stock>
    {
    }
}