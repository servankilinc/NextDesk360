using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ProductionModule;
using ExpressDesk360.DataAccess.Abstract.ProductionModule;

namespace ExpressDesk360.DataAccess.Concrete.ProductionModule
{
    public class CompanyProductStockSerialMapRepository : RepositoryBase<CompanyProductStockSerialMap, AppDbContext>, ICompanyProductStockSerialMapRepository
    {
        public CompanyProductStockSerialMapRepository(AppDbContext context) : base(context)
        {
        }
    }
}