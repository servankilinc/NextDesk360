using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities;

namespace ExpressDesk360.DataAccess.Concrete
{
    public class _TaskStaffRepository : RepositoryBase<_TaskStaff, AppDbContext>, I_TaskStaffRepository
    {
        public _TaskStaffRepository(AppDbContext context) : base(context)
        {
        }
    }
}