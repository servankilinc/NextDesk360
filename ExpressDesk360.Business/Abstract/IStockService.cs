using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.Stock.Commands;
using ExpressDesk360.Model.Dtos.Stock.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IStockService
    {
        Task<Result<Stock>> GetAsync(Expression<Func<Stock, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<Stock>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<StockDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Stock>>> GetListAsync(Expression<Func<Stock, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Stock>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<Stock, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(StockCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<StockUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(StockUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<Stock>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<Stock>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<Stock>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}