using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.CompanyModule;
using ExpressDesk360.DataAccess.Abstract.CompanyModule;

namespace ExpressDesk360.DataAccess.Concrete.CompanyModule;

public class CompanyRepository : RepositoryBase<Company, AppDbContext>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }
}