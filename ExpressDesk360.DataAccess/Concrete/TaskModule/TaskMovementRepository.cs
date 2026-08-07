using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.DataAccess.Abstract.TaskModule;

namespace ExpressDesk360.DataAccess.Concrete.TaskModule;

public class TaskMovementRepository : RepositoryBase<TaskMovement, AppDbContext>, ITaskMovementRepository
{
    public TaskMovementRepository(AppDbContext context) : base(context)
    {
    }
}