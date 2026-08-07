using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.TicketModule.TicketServicePrice.Commands;
using ExpressDesk360.Model.Dtos.TicketModule.TicketServicePrice.Queries;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.Business.Abstract.TicketModule;

public interface ITicketServicePriceService
{
    Task<Result<TicketServicePrice>> GetAsync(Expression<Func<TicketServicePrice, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<TicketServicePrice>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<TicketServicePriceDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketServicePrice>>> GetListAsync(Expression<Func<TicketServicePrice, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketServicePrice>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketServicePriceDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketServicePrice, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TicketServicePriceCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<TicketServicePriceUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(TicketServicePriceUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<TicketServicePrice>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<TicketServicePrice>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TicketServicePrice>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}