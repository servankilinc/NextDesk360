using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ShippingModule;

namespace ExpressDesk360.DataAccess.Abstract.ShippingModule
{
    public interface IShippingTypeRepository : IRepository<ShippingType>, IRepositoryAsync<ShippingType>
    {
    }
}