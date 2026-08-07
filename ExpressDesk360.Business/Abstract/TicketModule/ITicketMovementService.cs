using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.TicketModule.TicketMovement.Commands;
using ExpressDesk360.Model.Dtos.TicketModule.TicketMovement.Queries;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.Business.Abstract.TicketModule;

public interface ITicketMovementService
{
    Task<Result<TicketMovement>> GetAsync(Expression<Func<TicketMovement, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<TicketMovement>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<TicketMovementDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketMovement>>> GetListAsync(Expression<Func<TicketMovement, bool>>? where = default, Func<IQueryable<TicketMovement>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<TicketMovement, object?>>? include = default, Func<IQueryable<TicketMovement>, IOrderedQueryable<TicketMovement>>? orderBy = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketMovement>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketMovementDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketMovement, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TicketMovementCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<TicketMovement>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<TicketMovement>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TicketMovement>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}
