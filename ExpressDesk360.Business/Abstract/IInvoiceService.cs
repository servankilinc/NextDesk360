using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.Invoice.Commands;
using ExpressDesk360.Model.Dtos.Invoice.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IInvoiceService
    {
        Task<Result<Invoice>> GetAsync(Expression<Func<Invoice, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<Invoice>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<InvoiceDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Invoice>>> GetListAsync(Expression<Func<Invoice, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<Invoice>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<InvoiceDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<Invoice, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(InvoiceCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<InvoiceUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(InvoiceUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<Invoice>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<Invoice>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<Invoice>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}