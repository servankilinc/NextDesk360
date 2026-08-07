using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.StockModule.StockGroupFaultTypeMap.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockGroupFaultTypeMap.Queries;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Abstract.StockModule;

public interface IStockGroupFaultTypeMapService
{
    Task<Result<StockGroupFaultTypeMap>> GetAsync(Expression<Func<StockGroupFaultTypeMap, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<StockGroupFaultTypeMap>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<StockGroupFaultTypeMapDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockGroupFaultTypeMap>>> GetListAsync(Expression<Func<StockGroupFaultTypeMap, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockGroupFaultTypeMap>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockGroupFaultTypeMapDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(StockGroupFaultTypeMapCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<StockGroupFaultTypeMapUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(StockGroupFaultTypeMapUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<StockGroupFaultTypeMap>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<StockGroupFaultTypeMap>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<StockGroupFaultTypeMap>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}