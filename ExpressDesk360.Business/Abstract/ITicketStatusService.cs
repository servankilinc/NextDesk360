using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.TicketStatus.Commands;
using ExpressDesk360.Model.Dtos.TicketStatus.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface ITicketStatusService
    {
        Task<Result<TicketStatus>> GetAsync(Expression<Func<TicketStatus, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<TicketStatus>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<TicketStatusDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketStatus>>> GetListAsync(Expression<Func<TicketStatus, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketStatus>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketStatusDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketStatus, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TicketStatusCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<TicketStatus>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<TicketStatus>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<TicketStatus>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
