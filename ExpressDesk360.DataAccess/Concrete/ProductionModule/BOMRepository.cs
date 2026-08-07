using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ProductionModule;
using ExpressDesk360.DataAccess.Abstract.ProductionModule;

namespace ExpressDesk360.DataAccess.Concrete.ProductionModule
{
    public class BOMRepository : RepositoryBase<BOM, AppDbContext>, IBOMRepository
    {
        public BOMRepository(AppDbContext context) : base(context)
        {
        }
    }
}