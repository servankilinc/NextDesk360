using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.StockBrand.Commands;
using ExpressDesk360.Model.Dtos.StockBrand.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IStockBrandService
    {
        Task<Result<StockBrand>> GetAsync(Expression<Func<StockBrand, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<StockBrand>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<StockBrand>> GetDetailAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<StockBrandDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockBrand>>> GetListAsync(Expression<Func<StockBrand, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockBrand>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockBrandDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<StockBrand, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(StockBrandCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<StockBrandUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(StockBrandUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<StockBrand>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<StockBrand>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<StockBrandReportDto>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
