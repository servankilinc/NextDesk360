using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.StockModule.StockTypeGroupMap.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockTypeGroupMap.Queries;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Abstract.StockModule;

public interface IStockTypeGroupMapService
{
    Task<Result<StockTypeGroupMap>> GetAsync(Expression<Func<StockTypeGroupMap, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<StockTypeGroupMap>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<StockTypeGroupMapDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockTypeGroupMap>>> GetListAsync(Expression<Func<StockTypeGroupMap, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockTypeGroupMap>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockTypeGroupMapDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(StockTypeGroupMapCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<StockTypeGroupMapUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(StockTypeGroupMapUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<StockTypeGroupMap>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<StockTypeGroupMap>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<StockTypeGroupMap>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}