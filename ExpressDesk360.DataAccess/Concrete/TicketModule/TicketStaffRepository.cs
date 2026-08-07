using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TicketModule;
using ExpressDesk360.DataAccess.Abstract.TicketModule;

namespace ExpressDesk360.DataAccess.Concrete.TicketModule
{
    public class TicketStaffRepository : RepositoryBase<TicketStaff, AppDbContext>, ITicketStaffRepository
    {
        public TicketStaffRepository(AppDbContext context) : base(context)
        {
        }
    }
}