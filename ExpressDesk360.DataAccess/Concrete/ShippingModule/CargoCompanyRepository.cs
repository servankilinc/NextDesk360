using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ShippingModule;
using ExpressDesk360.DataAccess.Abstract.ShippingModule;

namespace ExpressDesk360.DataAccess.Concrete.ShippingModule;

public class CargoCompanyRepository : RepositoryBase<CargoCompany, AppDbContext>, ICargoCompanyRepository
{
    public CargoCompanyRepository(AppDbContext context) : base(context)
    {
    }
}