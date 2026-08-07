using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ShippingModule;
using ExpressDesk360.DataAccess.Abstract.ShippingModule;

namespace ExpressDesk360.DataAccess.Concrete.ShippingModule
{
    public class ShippingTypeRepository : RepositoryBase<ShippingType, AppDbContext>, IShippingTypeRepository
    {
        public ShippingTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}