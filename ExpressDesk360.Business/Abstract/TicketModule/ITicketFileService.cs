using System.Linq.Expressions;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Dtos.TicketModule.TicketFile.Commands;
using ExpressDesk360.Model.Dtos.TicketModule.TicketFile.Queries;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.Business.Abstract.TicketModule;

public interface ITicketFileService
{
    Task<Result<TicketFile>> GetAsync(Expression<Func<TicketFile, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<TicketFile>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<TicketFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketFile>>> GetListAsync(Expression<Func<TicketFile, bool>> where, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result<ICollection<TicketFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(TicketFileCreateDto request, CancellationToken cancellationToken = default);
    Task<Result<TicketFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(TicketFileUpdateDto request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginationResponse<TicketFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseClientSide<TicketFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    Task<Result<DatatableResponseServerSide<TicketFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
}