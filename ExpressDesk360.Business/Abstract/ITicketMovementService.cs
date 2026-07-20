using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.TicketMovement.Commands;
using ExpressDesk360.Model.Dtos.TicketMovement.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface ITicketMovementService
    {
        Task<Result<TicketMovement>> GetAsync(Expression<Func<TicketMovement, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<TicketMovement>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<TicketMovementDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMovement>>> GetListAsync(Expression<Func<TicketMovement, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMovement>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMovementDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketMovement, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TicketMovementCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TicketMovementUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TicketMovementUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<TicketMovement>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<TicketMovement>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<TicketMovement>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}