using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos._TaskFile.Commands;
using ExpressDesk360.Model.Dtos._TaskFile.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface I_TaskFileService
    {
        Task<Result<_TaskFile>> GetAsync(Expression<Func<_TaskFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<_TaskFile>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<TaskFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskFile>>> GetListAsync(Expression<Func<_TaskFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TaskFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TaskFileCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TaskFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TaskFileUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<_TaskFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<_TaskFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<_TaskFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}