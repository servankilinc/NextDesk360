using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.DataAccess.Abstract.TicketModule
{
    public interface ITicketStatusRepository : IRepository<TicketStatus>, IRepositoryAsync<TicketStatus>
    {
    }
}