using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.StockGroupBrandMap.Commands;
using ExpressDesk360.Model.Dtos.StockGroupBrandMap.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IStockGroupBrandMapService
    {
        Task<Result<StockGroupBrandMap>> GetAsync(Expression<Func<StockGroupBrandMap, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<StockGroupBrandMap>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<StockGroupBrandMapDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockGroupBrandMap>>> GetListAsync(Expression<Func<StockGroupBrandMap, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockGroupBrandMap>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockGroupBrandMapDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(StockGroupBrandMapCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<StockGroupBrandMapUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(StockGroupBrandMapUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<StockGroupBrandMap>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<StockGroupBrandMap>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<StockGroupBrandMap>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}