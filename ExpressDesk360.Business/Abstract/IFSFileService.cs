using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.FSFile.Commands;
using ExpressDesk360.Model.Dtos.FSFile.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IFSFileService
    {
        Task<Result<FSFile>> GetAsync(Expression<Func<FSFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<FSFile>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<FSFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<FSFile>>> GetListAsync(Expression<Func<FSFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<FSFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<FSFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<FSFile, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(FSFileCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<FSFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(FSFileUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<FSFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<FSFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<FSFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}