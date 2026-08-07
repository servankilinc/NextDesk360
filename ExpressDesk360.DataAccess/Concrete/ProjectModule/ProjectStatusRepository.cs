using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ProjectModule;
using ExpressDesk360.DataAccess.Abstract.ProjectModule;

namespace ExpressDesk360.DataAccess.Concrete.ProjectModule
{
    public class ProjectStatusRepository : RepositoryBase<ProjectStatus, AppDbContext>, IProjectStatusRepository
    {
        public ProjectStatusRepository(AppDbContext context) : base(context)
        {
        }
    }
}