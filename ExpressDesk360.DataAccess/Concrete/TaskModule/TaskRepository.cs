using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.DataAccess.Abstract.TaskModule;

namespace ExpressDesk360.DataAccess.Concrete.TaskModule;

public class TaskRepository : RepositoryBase<_Task, AppDbContext>, ITaskRepository
{
    public TaskRepository(AppDbContext context) : base(context)
    {
    }
}