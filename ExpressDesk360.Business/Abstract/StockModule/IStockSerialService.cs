using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.StockModule.StockSerial.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockSerial.Queries;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Abstract.StockModule;

public interface IStockSerialService
{
    Task<Result<StockSerial>> GetAsync(Expression<Func<StockSerial, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<StockSerial>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<StockSerial>> GetDetailAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<StockSerialDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockSerial>>> GetListAsync(Expression<Func<StockSerial, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockSerial>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<StockSerialDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<StockSerial, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(StockSerialCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<StockSerialUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(StockSerialUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<StockSerial>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<StockSerial>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<StockSerialReportDto>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}
