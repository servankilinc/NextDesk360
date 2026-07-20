using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.StockGroup.Commands;
using ExpressDesk360.Model.Dtos.StockGroup.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IStockGroupService
    {
        Task<Result<StockGroup>> GetAsync(Expression<Func<StockGroup, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<StockGroup>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<StockGroupDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockGroup>>> GetListAsync(Expression<Func<StockGroup, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockGroup>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<StockGroupDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<StockGroup, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(StockGroupCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<StockGroupUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(StockGroupUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<StockGroup>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<StockGroup>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<StockGroup>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}