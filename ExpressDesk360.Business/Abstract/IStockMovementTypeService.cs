using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.StockMovementType.Commands;
using ExpressDesk360.Model.Dtos.StockMovementType.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IStockMovementTypeService
    {
        Task<Result<StockMovementType>> GetAsync(Expression<Func<StockMovementType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<StockMovementType>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<StockMovementTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockMovementType>>> GetListAsync(Expression<Func<StockMovementType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockMovementType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockMovementTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<StockMovementType, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(StockMovementTypeCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<StockMovementTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(StockMovementTypeUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<StockMovementType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<StockMovementType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<StockMovementType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
