using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.InvoiceModule;

namespace ExpressDesk360.DataAccess.Abstract.InvoiceModule
{
    public interface IInvoiceTypeRepository : IRepository<InvoiceType>, IRepositoryAsync<InvoiceType>
    {
    }
}