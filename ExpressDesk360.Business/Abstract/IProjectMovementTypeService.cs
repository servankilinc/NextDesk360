using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.ProjectMovementType.Commands;
using ExpressDesk360.Model.Dtos.ProjectMovementType.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IProjectMovementTypeService
    {
        Task<Result<ProjectMovementType>> GetAsync(Expression<Func<ProjectMovementType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ProjectMovementType>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ProjectMovementTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectMovementType>>> GetListAsync(Expression<Func<ProjectMovementType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectMovementType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectMovementTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<ProjectMovementType, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(ProjectMovementTypeCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<ProjectMovementTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(ProjectMovementTypeUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<ProjectMovementType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<ProjectMovementType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<ProjectMovementType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}