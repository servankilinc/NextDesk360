using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.InvoiceType.Commands;
using ExpressDesk360.Model.Dtos.InvoiceType.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IInvoiceTypeService
    {
        Task<Result<InvoiceType>> GetAsync(Expression<Func<InvoiceType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<InvoiceType>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<InvoiceTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<InvoiceType>>> GetListAsync(Expression<Func<InvoiceType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<InvoiceType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<InvoiceTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<InvoiceType, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(InvoiceTypeCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<InvoiceTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(InvoiceTypeUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<InvoiceType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<InvoiceType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<InvoiceType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
