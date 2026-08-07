using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.ShippingModule.ShippingFile.Commands;
using ExpressDesk360.Model.Dtos.ShippingModule.ShippingFile.Queries;
using ExpressDesk360.Model.Entities.ShippingModule;

namespace ExpressDesk360.Business.Abstract.ShippingModule;

public interface IShippingFileService
{
    Task<Result<ShippingFile>> GetAsync(Expression<Func<ShippingFile, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ShippingFile>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ShippingFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<ShippingFile>>> GetListAsync(Expression<Func<ShippingFile, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<ShippingFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<ShippingFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(ShippingFileCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<ShippingFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(ShippingFileUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<ShippingFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<ShippingFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<ShippingFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}