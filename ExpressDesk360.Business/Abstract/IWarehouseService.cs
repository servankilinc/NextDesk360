using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.Warehouse.Commands;
using ExpressDesk360.Model.Dtos.Warehouse.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IWarehouseService
    {
        Task<Result<Warehouse>> GetAsync(Expression<Func<Warehouse, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<Warehouse>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<WarehouseDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Warehouse>>> GetListAsync(Expression<Func<Warehouse, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Warehouse>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<WarehouseDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<Warehouse, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(WarehouseCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<WarehouseUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(WarehouseUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<Warehouse>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<Warehouse>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<Warehouse>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}