using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.Shipping.Commands;
using ExpressDesk360.Model.Dtos.Shipping.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IShippingService
    {
        Task<Result<Shipping>> GetAsync(Expression<Func<Shipping, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<Shipping>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ShippingDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Shipping>>> GetListAsync(Expression<Func<Shipping, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Shipping>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ShippingDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<Shipping, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(ShippingCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<ShippingUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(ShippingUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<Shipping>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<Shipping>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<Shipping>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}