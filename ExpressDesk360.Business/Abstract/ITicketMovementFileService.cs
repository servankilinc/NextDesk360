using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.TicketMovementFile.Commands;
using ExpressDesk360.Model.Dtos.TicketMovementFile.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface ITicketMovementFileService
    {
        Task<Result<TicketMovementFile>> GetAsync(Expression<Func<TicketMovementFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<TicketMovementFile>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<TicketMovementFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMovementFile>>> GetListAsync(Expression<Func<TicketMovementFile, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMovementFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMovementFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TicketMovementFileCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TicketMovementFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TicketMovementFileUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<TicketMovementFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<TicketMovementFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<TicketMovementFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}