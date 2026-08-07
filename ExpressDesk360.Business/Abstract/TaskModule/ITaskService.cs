using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.Model.Dtos.TaskModule.Task.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.Task.Queries;

namespace ExpressDesk360.Business.Abstract.TaskModule;

public interface ITaskService
{
    Task<Result<_Task>> GetAsync(Expression<Func<_Task, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<_Task>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<TaskDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<_Task>>> GetListAsync(Expression<Func<_Task, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<_Task>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<_Task, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TaskCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<TaskUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(TaskUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<_Task>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<_Task>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<_Task>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}