using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.TicketModule.Ticket.Commands;
using ExpressDesk360.Model.Dtos.TicketModule.Ticket.Queries;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.Business.Abstract.TicketModule;

public interface ITicketService
{
    Task<Result<Ticket>> GetAsync(Expression<Func<Ticket, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<Ticket>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<TicketDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<Ticket>>> GetListAsync(Expression<Func<Ticket, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<Ticket>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<Ticket, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TicketCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<TicketUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(TicketUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<Ticket>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<Ticket>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TicketReportDto>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}