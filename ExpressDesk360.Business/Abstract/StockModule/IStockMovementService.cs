using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.StockModule.StockMovement.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockMovement.Queries;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Abstract.StockModule;

public interface IStockMovementService
{
    Task<Result<StockMovement>> GetAsync(Expression<Func<StockMovement, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<StockMovement>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<StockMovementDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockMovement>>> GetListAsync(Expression<Func<StockMovement, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockMovement>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockMovementDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<StockMovement, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(StockMovementCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<StockMovement>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<StockMovement>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<StockMovementReportDto>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}
