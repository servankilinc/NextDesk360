using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.InvoiceModule;
using ExpressDesk360.DataAccess.Abstract.InvoiceModule;

namespace ExpressDesk360.DataAccess.Concrete.InvoiceModule;

public class InvoiceRepository : RepositoryBase<Invoice, AppDbContext>, IInvoiceRepository
{
    public InvoiceRepository(AppDbContext context) : base(context)
    {
    }
}