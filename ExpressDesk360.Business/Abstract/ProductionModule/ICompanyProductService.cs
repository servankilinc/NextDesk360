using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProduct.Commands;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProduct.Queries;
using ExpressDesk360.Model.Entities.ProductionModule;

namespace ExpressDesk360.Business.Abstract.ProductionModule;

public interface ICompanyProductService
{
    Task<Result<CompanyProduct>> GetAsync(Expression<Func<CompanyProduct, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<CompanyProduct>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<CompanyProductDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyProduct>>> GetListAsync(Expression<Func<CompanyProduct, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyProduct>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyProductDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<CompanyProduct, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(CompanyProductCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<CompanyProductUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(CompanyProductUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<CompanyProduct>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<CompanyProduct>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<CompanyProduct>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}