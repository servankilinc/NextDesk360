using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.DataAccess.Abstract.TaskModule;

namespace ExpressDesk360.DataAccess.Concrete.TaskModule;

public class TaskStatusRepository : RepositoryBase<_TaskStatus, AppDbContext>, ITaskStatusRepository
{
    public TaskStatusRepository(AppDbContext context) : base(context)
    {
    }
}