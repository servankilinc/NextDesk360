using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.WarrantyType.Commands;
using ExpressDesk360.Model.Dtos.WarrantyType.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IWarrantyTypeService
    {
        Task<Result<WarrantyType>> GetAsync(Expression<Func<WarrantyType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<WarrantyType>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<WarrantyTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<WarrantyType>>> GetListAsync(Expression<Func<WarrantyType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<WarrantyType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<WarrantyTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<WarrantyType, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(WarrantyTypeCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<WarrantyTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(WarrantyTypeUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<WarrantyType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<WarrantyType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<WarrantyType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
