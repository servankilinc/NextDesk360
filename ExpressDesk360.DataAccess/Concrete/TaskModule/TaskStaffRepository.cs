using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.DataAccess.Abstract.TaskModule;

namespace ExpressDesk360.DataAccess.Concrete.TaskModule;

public class TaskStaffRepository : RepositoryBase<TaskStaff, AppDbContext>, ITaskStaffRepository
{
    public TaskStaffRepository(AppDbContext context) : base(context)
    {
    }
}