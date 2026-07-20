using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.CompanyProductWarranty.Commands;
using ExpressDesk360.Model.Dtos.CompanyProductWarranty.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface ICompanyProductWarrantyService
    {
        Task<Result<CompanyProductWarranty>> GetAsync(Expression<Func<CompanyProductWarranty, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<CompanyProductWarranty>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<CompanyProductWarrantyDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<CompanyProductWarranty>>> GetListAsync(Expression<Func<CompanyProductWarranty, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<CompanyProductWarranty>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<CompanyProductWarrantyDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(CompanyProductWarrantyCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<CompanyProductWarrantyUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(CompanyProductWarrantyUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<CompanyProductWarranty>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<CompanyProductWarranty>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<CompanyProductWarranty>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}