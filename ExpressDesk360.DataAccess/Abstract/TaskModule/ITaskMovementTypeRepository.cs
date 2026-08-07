using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.TaskModule;

namespace ExpressDesk360.DataAccess.Abstract.TaskModule;

public interface ITaskMovementTypeRepository : IRepository<TaskMovementType>, IRepositoryAsync<TaskMovementType>
{
}