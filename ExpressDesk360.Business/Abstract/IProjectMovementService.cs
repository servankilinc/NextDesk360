using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.ProjectMovement.Commands;
using ExpressDesk360.Model.Dtos.ProjectMovement.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IProjectMovementService
    {
        Task<Result<ProjectMovement>> GetAsync(Expression<Func<ProjectMovement, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ProjectMovement>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ProjectMovementDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectMovement>>> GetListAsync(Expression<Func<ProjectMovement, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectMovement>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectMovementDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<ProjectMovement, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(ProjectMovementCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<ProjectMovementUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(ProjectMovementUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<ProjectMovement>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<ProjectMovement>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<ProjectMovement>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}