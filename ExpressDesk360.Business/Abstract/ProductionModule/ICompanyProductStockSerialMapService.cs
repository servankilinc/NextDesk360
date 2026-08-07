using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductStockSerialMap.Commands;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductStockSerialMap.Queries;
using ExpressDesk360.Model.Entities.ProductionModule;

namespace ExpressDesk360.Business.Abstract.ProductionModule;

public interface ICompanyProductStockSerialMapService
{
    Task<Result<CompanyProductStockSerialMap>> GetAsync(Expression<Func<CompanyProductStockSerialMap, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<CompanyProductStockSerialMap>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<CompanyProductStockSerialMapDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyProductStockSerialMap>>> GetListAsync(Expression<Func<CompanyProductStockSerialMap, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyProductStockSerialMap>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<CompanyProductStockSerialMapDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(CompanyProductStockSerialMapCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<CompanyProductStockSerialMapUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(CompanyProductStockSerialMapUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<CompanyProductStockSerialMap>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<CompanyProductStockSerialMap>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<CompanyProductStockSerialMap>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}