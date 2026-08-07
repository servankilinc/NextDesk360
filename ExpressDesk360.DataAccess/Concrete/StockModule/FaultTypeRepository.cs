using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.StockModule;
using ExpressDesk360.DataAccess.Abstract.StockModule;

namespace ExpressDesk360.DataAccess.Concrete.StockModule;

public class FaultTypeRepository : RepositoryBase<FaultType, AppDbContext>, IFaultTypeRepository
{
    public FaultTypeRepository(AppDbContext context) : base(context)
    {
    }
}