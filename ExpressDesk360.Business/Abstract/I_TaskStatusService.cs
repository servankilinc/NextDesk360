using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos._TaskStatus.Commands;
using ExpressDesk360.Model.Dtos._TaskStatus.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface I_TaskStatusService
    {
        Task<Result<_TaskStatus>> GetAsync(Expression<Func<_TaskStatus, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<_TaskStatus>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<TaskStatusDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskStatus>>> GetListAsync(Expression<Func<_TaskStatus, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskStatus>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TaskStatusDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<_TaskStatus, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TaskStatusCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<_TaskStatus>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<_TaskStatus>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<_TaskStatus>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
