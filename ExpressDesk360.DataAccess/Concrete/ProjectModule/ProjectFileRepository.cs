using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.ProjectModule;
using ExpressDesk360.DataAccess.Abstract.ProjectModule;

namespace ExpressDesk360.DataAccess.Concrete.ProjectModule;

public class ProjectFileRepository : RepositoryBase<ProjectFile, AppDbContext>, IProjectFileRepository
{
    public ProjectFileRepository(AppDbContext context) : base(context)
    {
    }
}