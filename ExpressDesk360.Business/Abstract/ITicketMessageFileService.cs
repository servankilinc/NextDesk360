using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.TicketMessageFile.Commands;
using ExpressDesk360.Model.Dtos.TicketMessageFile.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface ITicketMessageFileService
    {
        Task<Result<TicketMessageFile>> GetAsync(Expression<Func<TicketMessageFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<TicketMessageFile>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<TicketMessageFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMessageFile>>> GetListAsync(Expression<Func<TicketMessageFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMessageFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMessageFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TicketMessageFileCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TicketMessageFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TicketMessageFileUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<TicketMessageFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<TicketMessageFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<TicketMessageFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}