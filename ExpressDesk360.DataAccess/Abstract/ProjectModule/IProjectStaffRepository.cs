using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ProjectModule;

namespace ExpressDesk360.DataAccess.Abstract.ProjectModule
{
    public interface IProjectStaffRepository : IRepository<ProjectStaff>, IRepositoryAsync<ProjectStaff>
    {
    }
}