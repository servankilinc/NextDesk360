using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.DataAccess.Abstract.StockModule;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.DataAccess.Concrete.StockModule
{
    public class StockTypeRepository : RepositoryBase<StockType, AppDbContext>, IStockTypeRepository
    {
        public StockTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}