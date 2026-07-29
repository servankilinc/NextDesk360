using AutoMapper;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Core.Utils.Validation;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.UoW;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.CargoCompany.Commands;
using ExpressDesk360.Model.Dtos.CargoCompany.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public CargoCompanyService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<CargoCompany>> GetAsync(Expression<Func<CargoCompany, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CargoCompanies.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CargoCompany>.NotFound();
            return Result<CargoCompany>.Success(result);
        }

        public async Task<Result<CargoCompany>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CargoCompanies.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CargoCompany>.NotFound();
            return Result<CargoCompany>.Success(result);
        }

        public async Task<Result<CargoCompanyDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CargoCompanies.GetAsync<CargoCompanyDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CargoCompanyDto>.NotFound();
            return Result<CargoCompanyDto>.Success(result);
        }

        public async Task<Result<ICollection<CargoCompany>>> GetListAsync(Expression<Func<CargoCompany, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CargoCompanies.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CargoCompany>>.NotFound();
            return Result<ICollection<CargoCompany>>.Success(result);
        }

        public async Task<Result<ICollection<CargoCompany>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CargoCompanies.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CargoCompany>>.NotFound();
            return Result<ICollection<CargoCompany>>.Success(result);
        }

        public async Task<Result<ICollection<CargoCompanyDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CargoCompanies.GetAllAsync<CargoCompanyDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CargoCompanyDto>>.NotFound();
            return Result<ICollection<CargoCompanyDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<CargoCompany, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.CargoCompanies.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(CargoCompanyCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for CargoCompanyCreateDto");
            await _unitOfWork.CargoCompanies.AddAndSaveAsync(_mapper.Map<CargoCompany>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<CargoCompanyUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CargoCompanies.GetAsync<CargoCompanyUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CargoCompanyUpdateDto>.NotFound();
            return Result<CargoCompanyUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(CargoCompanyUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.CargoCompanies.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.CargoCompanies.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<CargoCompany>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CargoCompanies.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<CargoCompany>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<CargoCompany>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CargoCompanies.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<CargoCompany>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<CargoCompany>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CargoCompanies.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<CargoCompany>>.Success(result);
        }
    }
}
