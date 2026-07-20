using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities;

namespace ExpressDesk360.DataAccess.Abstract
{
    public interface IStockTypeRepository : IRepository<StockType>, IRepositoryAsync<StockType>
    {
    }
}