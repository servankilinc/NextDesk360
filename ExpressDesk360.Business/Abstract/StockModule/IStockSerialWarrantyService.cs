using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.StockModule.StockSerialWarranty.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockSerialWarranty.Queries;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Abstract.StockModule;

public interface IStockSerialWarrantyService
{
    Task<Result<StockSerialWarranty>> GetAsync(Expression<Func<StockSerialWarranty, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<StockSerialWarranty>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<StockSerialWarrantyDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockSerialWarranty>>> GetListAsync(Expression<Func<StockSerialWarranty, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockSerialWarranty>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockSerialWarrantyDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(StockSerialWarrantyCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<StockSerialWarrantyUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(StockSerialWarrantyUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<StockSerialWarranty>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<StockSerialWarranty>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<StockSerialWarranty>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}