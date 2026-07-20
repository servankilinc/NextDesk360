using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities;

namespace ExpressDesk360.DataAccess.Concrete
{
    public class CompanyFileRepository : RepositoryBase<CompanyFile, AppDbContext>, ICompanyFileRepository
    {
        public CompanyFileRepository(AppDbContext context) : base(context)
        {
        }
    }
}