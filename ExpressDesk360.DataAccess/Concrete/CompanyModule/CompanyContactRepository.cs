using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.CompanyModule;
using ExpressDesk360.DataAccess.Abstract.CompanyModule;

namespace ExpressDesk360.DataAccess.Concrete.CompanyModule
{
    public class CompanyContactRepository : RepositoryBase<CompanyContact, AppDbContext>, ICompanyContactRepository
    {
        public CompanyContactRepository(AppDbContext context) : base(context)
        {
        }
    }
}