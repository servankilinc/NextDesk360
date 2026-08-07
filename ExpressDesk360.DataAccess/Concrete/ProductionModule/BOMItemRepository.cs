using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ProductionModule;
using ExpressDesk360.DataAccess.Abstract.ProductionModule;

namespace ExpressDesk360.DataAccess.Concrete.ProductionModule;

public class BOMItemRepository : RepositoryBase<BOMItem, AppDbContext>, IBOMItemRepository
{
    public BOMItemRepository(AppDbContext context) : base(context)
    {
    }
}