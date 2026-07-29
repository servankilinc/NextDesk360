using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.TicketType.Commands;
using ExpressDesk360.Model.Dtos.TicketType.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface ITicketTypeService
    {
        Task<Result<TicketType>> GetAsync(Expression<Func<TicketType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<TicketType>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<TicketTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketType>>> GetListAsync(Expression<Func<TicketType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<TicketTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketType, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(TicketTypeCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<TicketTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(TicketTypeUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<TicketType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<TicketType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<TicketType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
