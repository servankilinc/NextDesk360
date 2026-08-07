using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.DataAccess.Abstract.StockModule
{
    public interface IStockBrandRepository : IRepository<StockBrand>, IRepositoryAsync<StockBrand>
    {
    }
}