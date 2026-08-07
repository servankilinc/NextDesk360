using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TaskModule;

namespace ExpressDesk360.DataAccess.Abstract.TaskModule;

public interface ITaskFileRepository : IRepository<TaskFile>, IRepositoryAsync<TaskFile>
{
}