using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ProjectModule;
using ExpressDesk360.DataAccess.Abstract.ProjectModule;

namespace ExpressDesk360.DataAccess.Concrete.ProjectModule
{
    public class ProjectMovementTypeRepository : RepositoryBase<ProjectMovementType, AppDbContext>, IProjectMovementTypeRepository
    {
        public ProjectMovementTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}