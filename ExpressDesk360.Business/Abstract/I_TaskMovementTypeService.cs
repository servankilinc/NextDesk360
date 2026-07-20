using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos._TaskMovementType.Commands;
using ExpressDesk360.Model.Dtos._TaskMovementType.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface I_TaskMovementTypeService
    {
        Task<Result<_TaskMovementType>> GetAsync(Expression<Func<_TaskMovementType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<_TaskMovementType>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<TaskMovementTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskMovementType>>> GetListAsync(Expression<Func<_TaskMovementType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskMovementType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TaskMovementTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<_TaskMovementType, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TaskMovementTypeCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TaskMovementTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TaskMovementTypeUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<_TaskMovementType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<_TaskMovementType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<_TaskMovementType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}