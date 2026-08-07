using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.CompanyModule;

namespace ExpressDesk360.DataAccess.Abstract.CompanyModule
{
    public interface ICompanyContactRepository : IRepository<CompanyContact>, IRepositoryAsync<CompanyContact>
    {
    }
}