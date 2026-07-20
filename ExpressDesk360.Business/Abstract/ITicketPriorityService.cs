using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.TicketPriority.Commands;
using ExpressDesk360.Model.Dtos.TicketPriority.Queries;

namespace ExpressDesk360.Business.Abstract
{
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
        Task<Result<TicketPriorityUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TicketPriorityUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<TicketPriority>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<TicketPriority>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<TicketPriority>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}