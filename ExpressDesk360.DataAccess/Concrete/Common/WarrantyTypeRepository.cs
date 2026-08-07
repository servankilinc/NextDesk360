using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.Common;
using ExpressDesk360.DataAccess.Abstract.Common;

namespace ExpressDesk360.DataAccess.Concrete.Common
{
    public class WarrantyTypeRepository : RepositoryBase<WarrantyType, AppDbContext>, IWarrantyTypeRepository
    {
        public WarrantyTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}