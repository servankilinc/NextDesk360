using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.Common;
using ExpressDesk360.DataAccess.Abstract.Common;

namespace ExpressDesk360.DataAccess.Concrete.Common;

public class ContactTypeRepository : RepositoryBase<ContactType, AppDbContext>, IContactTypeRepository
{
    public ContactTypeRepository(AppDbContext context) : base(context)
    {
    }
}