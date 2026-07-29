using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.Currency.Commands;
using ExpressDesk360.Model.Dtos.Currency.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface ICurrencyService
    {
        Task<Result<Currency>> GetAsync(Expression<Func<Currency, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<Currency>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<CurrencyDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Currency>>> GetListAsync(Expression<Func<Currency, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Currency>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<CurrencyDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<Currency, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(CurrencyCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<CurrencyUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(CurrencyUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<Currency>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<Currency>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<Currency>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
