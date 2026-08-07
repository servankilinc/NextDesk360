using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.TaskModule.TaskFile.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.TaskFile.Queries;
using ExpressDesk360.Model.Entities.TaskModule;

namespace ExpressDesk360.Business.Abstract.TaskModule;

public interface ITaskFileService
{
    Task<Result<TaskFile>> GetAsync(Expression<Func<TaskFile, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<TaskFile>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<TaskFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskFile>>> GetListAsync(Expression<Func<TaskFile, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TaskFileCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<TaskFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(TaskFileUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<TaskFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<TaskFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TaskFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}