using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.DataAccess.Abstract.TicketModule
{
    public interface ITicketServicePriceRepository : IRepository<TicketServicePrice>, IRepositoryAsync<TicketServicePrice>
    {
    }
}