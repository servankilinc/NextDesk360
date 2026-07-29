using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.UserFile.Commands;
using ExpressDesk360.Model.Dtos.UserFile.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IUserFileService
    {
        Task<Result<UserFile>> GetAsync(Expression<Func<UserFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<UserFile>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<UserFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<UserFile>>> GetListAsync(Expression<Func<UserFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<UserFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<UserFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(UserFileCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<UserFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(UserFileUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<UserFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<UserFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<UserFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}