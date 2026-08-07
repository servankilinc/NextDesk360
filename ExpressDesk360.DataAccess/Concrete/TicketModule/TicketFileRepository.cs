using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TicketModule;
using ExpressDesk360.DataAccess.Abstract.TicketModule;

namespace ExpressDesk360.DataAccess.Concrete.TicketModule;

public class TicketFileRepository : RepositoryBase<TicketFile, AppDbContext>, ITicketFileRepository
{
    public TicketFileRepository(AppDbContext context) : base(context)
    {
    }
}