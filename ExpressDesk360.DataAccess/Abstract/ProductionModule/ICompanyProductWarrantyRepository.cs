using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ProductionModule;

namespace ExpressDesk360.DataAccess.Abstract.ProductionModule
{
    public interface ICompanyProductWarrantyRepository : IRepository<CompanyProductWarranty>, IRepositoryAsync<CompanyProductWarranty>
    {
    }
}