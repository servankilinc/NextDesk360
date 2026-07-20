using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.ProjectStaff.Commands;
using ExpressDesk360.Model.Dtos.ProjectStaff.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IProjectStaffService
    {
        Task<Result<ProjectStaff>> GetAsync(Expression<Func<ProjectStaff, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ProjectStaff>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ProjectStaffDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectStaff>>> GetListAsync(Expression<Func<ProjectStaff, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectStaff>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectStaffDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(ProjectStaffCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<ProjectStaffUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(ProjectStaffUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<ProjectStaff>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<ProjectStaff>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<ProjectStaff>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}