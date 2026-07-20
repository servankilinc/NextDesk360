using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.BOM.Commands;
using ExpressDesk360.Model.Dtos.BOM.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IBOMService
    {
        Task<Result<BOM>> GetAsync(Expression<Func<BOM, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<BOM>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<BOMDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<BOM>>> GetListAsync(Expression<Func<BOM, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<BOM>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<BOMDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<BOM, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(BOMCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<BOMUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(BOMUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<BOM>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<BOM>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<BOM>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}