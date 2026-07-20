using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.Project.Commands;
using ExpressDesk360.Model.Dtos.Project.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IProjectService
    {
        Task<Result<Project>> GetAsync(Expression<Func<Project, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<Project>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ProjectDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Project>>> GetListAsync(Expression<Func<Project, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Project>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<Project, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(ProjectCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<ProjectUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(ProjectUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<Project>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<Project>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<Project>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}