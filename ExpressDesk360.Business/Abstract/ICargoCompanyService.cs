using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.CargoCompany.Commands;
using ExpressDesk360.Model.Dtos.CargoCompany.Queries;

namespace ExpressDesk360.Business.Abstract
{
    public interface ICargoCompanyService
    {
        Task<Result<CargoCompany>> GetAsync(Expression<Func<CargoCompany, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<CargoCompany>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<CargoCompanyDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<ICollection<CargoCompany>>> GetListAsync(Expression<Func<CargoCompany, bool>> where, CancellationToken cancellationToken = default);
        Task<Result<ICollection<CargoCompany>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<ICollection<CargoCompanyDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default);
        Task<Result<SelectList>> SelectListAsync(Expression<Func<CargoCompany, bool>>? where = default, CancellationToken cancellationToken = default);
        Task<Result> CreateAsync(CargoCompanyCreateDto request, CancellationToken cancellationToken = default);
        Task<Result<CargoCompanyUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(CargoCompanyUpdateDto request, CancellationToken cancellationToken = default);
        Task<Result<PaginationResponse<CargoCompany>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseClientSide<CargoCompany>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
        Task<Result<DatatableResponseServerSide<CargoCompany>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default);
    }
}
