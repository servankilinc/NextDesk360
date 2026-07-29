using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.ProjectFile.Commands;
using ExpressDesk360.Model.Dtos.ProjectFile.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IProjectFileService
    {
        Task<Result<ProjectFile>> GetAsync(Expression<Func<ProjectFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ProjectFile>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ProjectFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectFile>>> GetListAsync(Expression<Func<ProjectFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ProjectFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(ProjectFileCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<ProjectFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(ProjectFileUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<ProjectFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<ProjectFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<ProjectFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}