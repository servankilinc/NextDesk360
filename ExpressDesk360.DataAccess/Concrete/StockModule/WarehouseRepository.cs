using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.StockModule;
using ExpressDesk360.DataAccess.Abstract.StockModule;

namespace ExpressDesk360.DataAccess.Concrete.StockModule
{
    public class WarehouseRepository : RepositoryBase<Warehouse, AppDbContext>, IWarehouseRepository
    {
        public WarehouseRepository(AppDbContext context) : base(context)
        {
        }
    }
}