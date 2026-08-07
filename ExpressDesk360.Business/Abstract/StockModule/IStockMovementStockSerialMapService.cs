using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.StockModule.StockMovementStockSerialMap.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockMovementStockSerialMap.Queries;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Abstract.StockModule;

public interface IStockMovementStockSerialMapService
{
    Task<Result<StockMovementStockSerialMap>> GetAsync(Expression<Func<StockMovementStockSerialMap, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<StockMovementStockSerialMap>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<StockMovementStockSerialMapDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockMovementStockSerialMap>>> GetListAsync(Expression<Func<StockMovementStockSerialMap, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockMovementStockSerialMap>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockMovementStockSerialMapDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(StockMovementStockSerialMapCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<StockMovementStockSerialMapUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(StockMovementStockSerialMapUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<StockMovementStockSerialMap>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<StockMovementStockSerialMap>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<StockMovementStockSerialMap>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}