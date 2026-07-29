using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.ContactType.Commands;
using ExpressDesk360.Model.Dtos.ContactType.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IContactTypeService
    {
        Task<Result<ContactType>> GetAsync(Expression<Func<ContactType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ContactType>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ContactTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ContactType>>> GetListAsync(Expression<Func<ContactType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ContactType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<ContactTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<ContactType, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(ContactTypeCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<ContactTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(ContactTypeUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<ContactType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<ContactType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<ContactType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
