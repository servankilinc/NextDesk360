using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.Unit.Commands;
using ExpressDesk360.Model.Dtos.Unit.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IUnitService
    {
        Task<Result<Unit>> GetAsync(Expression<Func<Unit, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<Unit>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<UnitDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Unit>>> GetListAsync(Expression<Func<Unit, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Unit>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<UnitDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<Unit, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(UnitCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<UnitUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(UnitUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<Unit>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<Unit>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<Unit>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}