using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.TicketModule.TicketPriority.Commands;
using ExpressDesk360.Model.Dtos.TicketModule.TicketPriority.Queries;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.Business.Abstract.TicketModule;

public interface ITicketPriorityService
{
    Task<Result<TicketPriority>> GetAsync(Expression<Func<TicketPriority, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<TicketPriority>> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<TicketPriorityDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketPriority>>> GetListAsync(Expression<Func<TicketPriority, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketPriority>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketPriorityDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketPriority, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TicketPriorityCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<TicketPriority>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<TicketPriority>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TicketPriority>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}
