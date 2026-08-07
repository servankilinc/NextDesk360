using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.TicketModule.TicketStaff.Commands;
using ExpressDesk360.Model.Dtos.TicketModule.TicketStaff.Queries;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.Business.Abstract.TicketModule;

public interface ITicketStaffService
{
    Task<Result<TicketStaff>> GetAsync(Expression<Func<TicketStaff, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<TicketStaff>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<TicketStaffDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketStaff>>> GetListAsync(Expression<Func<TicketStaff, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketStaff>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketStaffDto>>> GetBaseListAsync(Expression<Func<TicketStaff, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketStaffDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TicketStaffCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<TicketStaffUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(TicketStaffUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<TicketStaff>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<TicketStaff>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TicketStaff>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}