using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.TicketMovementType.Commands;
using ExpressDesk360.Model.Dtos.TicketMovementType.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface ITicketMovementTypeService
    {
        Task<Result<TicketMovementType>> GetAsync(Expression<Func<TicketMovementType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<TicketMovementType>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<TicketMovementTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMovementType>>> GetListAsync(Expression<Func<TicketMovementType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMovementType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketMovementTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketMovementType, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TicketMovementTypeCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TicketMovementTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TicketMovementTypeUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<TicketMovementType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<TicketMovementType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<TicketMovementType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
