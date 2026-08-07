using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.InvoiceModule;
using ExpressDesk360.DataAccess.Abstract.InvoiceModule;

namespace ExpressDesk360.DataAccess.Concrete.InvoiceModule
{
    public class InvoiceTypeRepository : RepositoryBase<InvoiceType, AppDbContext>, IInvoiceTypeRepository
    {
        public InvoiceTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}