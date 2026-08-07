using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyFile.Commands;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyFile.Queries;
using ExpressDesk360.Model.Entities.CompanyModule;

namespace ExpressDesk360.Business.Abstract.CompanyModule;

public interface ICompanyFileService
{
    Task<Result<CompanyFile>> GetAsync(Expression<Func<CompanyFile, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<CompanyFile>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<CompanyFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyFile>>> GetListAsync(Expression<Func<CompanyFile, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(CompanyFileCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<CompanyFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(CompanyFileUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<CompanyFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<CompanyFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<CompanyFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}