using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos._TaskMovement.Commands;
using ExpressDesk360.Model.Dtos._TaskMovement.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface I_TaskMovementService
    {
        Task<Result<_TaskMovement>> GetAsync(Expression<Func<_TaskMovement, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<_TaskMovement>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<TaskMovementDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskMovement>>> GetListAsync(Expression<Func<_TaskMovement, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskMovement>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TaskMovementDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<_TaskMovement, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TaskMovementCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TaskMovementUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TaskMovementUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<_TaskMovement>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<_TaskMovement>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<_TaskMovement>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}