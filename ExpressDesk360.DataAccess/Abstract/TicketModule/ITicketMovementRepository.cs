using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.DataAccess.Abstract.TicketModule
{
    public interface ITicketMovementRepository : IRepository<TicketMovement>, IRepositoryAsync<TicketMovement>
    {
    }
}