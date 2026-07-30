using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.FaultType.Commands;
using ExpressDesk360.Model.Dtos.FaultType.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface IFaultTypeService
    {
        Task<Result<FaultType>> GetAsync(Expression<Func<FaultType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<FaultType>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<FaultType>> GetDetailAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<FaultTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<FaultType>>> GetListAsync(Expression<Func<FaultType, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<FaultType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<FaultTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<FaultType, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(FaultTypeCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<FaultTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(FaultTypeUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<FaultType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<FaultType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<FaultTypeReportDto>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
