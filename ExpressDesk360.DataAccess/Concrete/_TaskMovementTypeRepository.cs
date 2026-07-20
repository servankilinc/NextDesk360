using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities;

namespace ExpressDesk360.DataAccess.Concrete
{
    public class _TaskMovementTypeRepository : RepositoryBase<_TaskMovementType, AppDbContext>, I_TaskMovementTypeRepository
    {
        public _TaskMovementTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}