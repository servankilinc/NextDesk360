using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.UserContact.Commands;
using ExpressDesk360.Model.Dtos.UserContact.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IUserContactService
    {
        Task<Result<UserContact>> GetAsync(Expression<Func<UserContact, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<UserContact>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<UserContactDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<UserContact>>> GetListAsync(Expression<Func<UserContact, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<UserContact>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<UserContactDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<UserContact, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(UserContactCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<UserContactUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(UserContactUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<UserContact>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<UserContact>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<UserContact>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}