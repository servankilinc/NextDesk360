using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.TicketMessage.Commands;
using ExpressDesk360.Model.Dtos.TicketMessage.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface ITicketMessageService
    {
        Task<Result<TicketMessage>> GetAsync(Expression<Func<TicketMessage, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<TicketMessage>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<TicketMessageDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMessage>>> GetListAsync(Expression<Func<TicketMessage, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMessage>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMessageDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketMessage, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TicketMessageCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TicketMessageUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TicketMessageUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<TicketMessage>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<TicketMessage>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<TicketMessage>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}