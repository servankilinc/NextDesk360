using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.DataAccess.Abstract.TaskModule;

namespace ExpressDesk360.DataAccess.Concrete.TaskModule;

public class TaskMovementTypeRepository : RepositoryBase<TaskMovementType, AppDbContext>, ITaskMovementTypeRepository
{
    public TaskMovementTypeRepository(AppDbContext context) : base(context)
    {
    }
}