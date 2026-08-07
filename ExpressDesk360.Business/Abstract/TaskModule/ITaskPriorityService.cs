using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.Model.Dtos.TaskModule.TaskPriority.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.TaskPriority.Queries;

namespace ExpressDesk360.Business.Abstract.TaskModule;

public interface ITaskPriorityService
{
    Task<Result<TaskPriority>> GetAsync(Expression<Func<TaskPriority, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<TaskPriority>> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<TaskPriorityDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskPriority>>> GetListAsync(Expression<Func<TaskPriority, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskPriority>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskPriorityDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<TaskPriority, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TaskPriorityCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<TaskPriority>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<TaskPriority>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TaskPriority>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}
