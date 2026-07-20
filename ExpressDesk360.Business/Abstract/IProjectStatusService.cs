using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.ProjectStatus.Commands;
using ExpressDesk360.Model.Dtos.ProjectStatus.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IProjectStatusService
    {
        Task<Result<ProjectStatus>> GetAsync(Expression<Func<ProjectStatus, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ProjectStatus>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ProjectStatusDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectStatus>>> GetListAsync(Expression<Func<ProjectStatus, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectStatus>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectStatusDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<ProjectStatus, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(ProjectStatusCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<ProjectStatusUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(ProjectStatusUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<ProjectStatus>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<ProjectStatus>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<ProjectStatus>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}