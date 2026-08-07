using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyContact.Commands;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyContact.Queries;
using ExpressDesk360.Model.Entities.CompanyModule;

namespace ExpressDesk360.Business.Abstract.CompanyModule;

public interface ICompanyContactService
{
    Task<Result<CompanyContact>> GetAsync(Expression<Func<CompanyContact, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<CompanyContact>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<CompanyContactDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyContact>>> GetListAsync(Expression<Func<CompanyContact, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyContact>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyContactDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<CompanyContact, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(CompanyContactCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<CompanyContactUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(CompanyContactUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<CompanyContact>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<CompanyContact>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<CompanyContact>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}