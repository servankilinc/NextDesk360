using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.ShippingType.Commands;
using ExpressDesk360.Model.Dtos.ShippingType.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IShippingTypeService
    {
        Task<Result<ShippingType>> GetAsync(Expression<Func<ShippingType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ShippingType>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ShippingTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ShippingType>>> GetListAsync(Expression<Func<ShippingType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ShippingType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ShippingTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<ShippingType, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(ShippingTypeCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<ShippingTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(ShippingTypeUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<ShippingType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<ShippingType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<ShippingType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
