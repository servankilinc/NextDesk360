using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos._TaskPriority.Commands;
using ExpressDesk360.Model.Dtos._TaskPriority.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface I_TaskPriorityService
    {
        Task<Result<_TaskPriority>> GetAsync(Expression<Func<_TaskPriority, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<_TaskPriority>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<TaskPriorityDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskPriority>>> GetListAsync(Expression<Func<_TaskPriority, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskPriority>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TaskPriorityDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<_TaskPriority, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TaskPriorityCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TaskPriorityUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TaskPriorityUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<_TaskPriority>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<_TaskPriority>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<_TaskPriority>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}