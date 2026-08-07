using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TaskModule;

namespace ExpressDesk360.DataAccess.Abstract.TaskModule;

public interface ITaskStatusRepository : IRepository<_TaskStatus>, IRepositoryAsync<_TaskStatus>
{
}