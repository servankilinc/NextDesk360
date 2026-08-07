using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.TaskModule.TaskStaff.Commands;
using ExpressDesk360.Model.Dtos.TaskModule.TaskStaff.Queries;
using ExpressDesk360.Model.Entities.TaskModule;

namespace ExpressDesk360.Business.Abstract.TaskModule;

public interface ITaskStaffService
{
    Task<Result<TaskStaff>> GetAsync(Expression<Func<TaskStaff, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<TaskStaff>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<TaskStaffDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskStaff>>> GetListAsync(Expression<Func<TaskStaff, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskStaff>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TaskStaffDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TaskStaffCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<TaskStaffUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(TaskStaffUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<TaskStaff>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<TaskStaff>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TaskStaff>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}