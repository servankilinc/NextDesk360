using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.ProductionModule.BOMItem.Commands;
using ExpressDesk360.Model.Dtos.ProductionModule.BOMItem.Queries;
using ExpressDesk360.Model.Entities.ProductionModule;

namespace ExpressDesk360.Business.Abstract.ProductionModule;

public interface IBOMItemService
{
    Task<Result<BOMItem>> GetAsync(Expression<Func<BOMItem, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<BOMItem>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<BOMItemDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<BOMItem>>> GetListAsync(Expression<Func<BOMItem, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<BOMItem>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<BOMItemDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(BOMItemCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<BOMItemUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(BOMItemUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<BOMItem>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<BOMItem>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<BOMItem>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}