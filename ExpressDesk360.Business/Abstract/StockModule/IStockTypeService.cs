using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.StockModule.StockType.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockType.Queries;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Abstract.StockModule;

public interface IStockTypeService
{
    Task<Result<StockType>> GetAsync(Expression<Func<StockType, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<StockType>> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<StockTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockType>>> GetListAsync(Expression<Func<StockType, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<StockType, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(StockTypeCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<StockTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(StockTypeUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<StockType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<StockType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<StockType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}
