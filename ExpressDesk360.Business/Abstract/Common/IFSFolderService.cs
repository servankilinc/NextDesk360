using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.Common.FSFolder.Commands;
using ExpressDesk360.Model.Dtos.Common.FSFolder.Queries;
using ExpressDesk360.Model.Entities.Common;

namespace ExpressDesk360.Business.Abstract.Common;

public interface IFSFolderService
{
    Task<Result<FSFolder>> GetAsync(Expression<Func<FSFolder, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<FSFolder>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<FSFolderDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<FSFolder>>> GetListAsync(Expression<Func<FSFolder, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<FSFolder>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<FSFolderDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<SelectList>> SelectListAsync(Expression<Func<FSFolder, bool>>? where = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(FSFolderCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<FSFolderUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(FSFolderUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<FSFolder>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<FSFolder>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<FSFolder>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}