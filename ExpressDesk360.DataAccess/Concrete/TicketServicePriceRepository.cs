using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities;

namespace ExpressDesk360.DataAccess.Concrete
{
    public class TicketServicePriceRepository : RepositoryBase<TicketServicePrice, AppDbContext>, ITicketServicePriceRepository
    {
        public TicketServicePriceRepository(AppDbContext context) : base(context)
        {
        }
    }
}