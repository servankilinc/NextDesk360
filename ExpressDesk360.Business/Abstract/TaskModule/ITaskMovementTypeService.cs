using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovementType.Queries;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovementType.Commands;

namespace ExpressDesk360.Business.Abstract.TaskModule;

public interface ITaskMovementTypeService
{
    Task<Result<TaskMovementType>> GetAsync(Expression<Func<TaskMovementType, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<TaskMovementType>> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<TaskMovementTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskMovementType>>> GetListAsync(Expression<Func<TaskMovementType, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskMovementType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskMovementTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<TaskMovementType, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TaskMovementTypeCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<TaskMovementTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(TaskMovementTypeUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<TaskMovementType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<TaskMovementType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TaskMovementType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}
