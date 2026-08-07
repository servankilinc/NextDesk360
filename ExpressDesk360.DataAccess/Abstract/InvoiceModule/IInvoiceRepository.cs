using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.InvoiceModule;

namespace ExpressDesk360.DataAccess.Abstract.InvoiceModule;

public interface IInvoiceRepository : IRepository<Invoice>, IRepositoryAsync<Invoice>
{
}