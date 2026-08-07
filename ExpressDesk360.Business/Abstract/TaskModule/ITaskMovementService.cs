using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovement.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovement.Queries;

namespace ExpressDesk360.Business.Abstract.TaskModule;

public interface ITaskMovementService
{
    Task<Result<TaskMovement>> GetAsync(Expression<Func<TaskMovement, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<TaskMovement>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<TaskMovementDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskMovement>>> GetListAsync(Expression<Func<TaskMovement, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskMovement>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskMovementDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<TaskMovement, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TaskMovementCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<TaskMovement>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<TaskMovement>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TaskMovement>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}
