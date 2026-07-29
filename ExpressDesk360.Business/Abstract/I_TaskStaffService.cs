using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos._TaskStaff.Commands;
using ExpressDesk360.Model.Dtos._TaskStaff.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface I_TaskStaffService
    {
        Task<Result<_TaskStaff>> GetAsync(Expression<Func<_TaskStaff, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<_TaskStaff>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<TaskStaffDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskStaff>>> GetListAsync(Expression<Func<_TaskStaff, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<_TaskStaff>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TaskStaffDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TaskStaffCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TaskStaffUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TaskStaffUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<_TaskStaff>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<_TaskStaff>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<_TaskStaff>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}