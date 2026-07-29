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
using ExpressDesk360.Model.Dtos.CompanyProductStockSerialMap.Commands;
using ExpressDesk360.Model.Dtos.CompanyProductStockSerialMap.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class CompanyProductStockSerialMapService : ICompanyProductStockSerialMapService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public CompanyProductStockSerialMapService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<CompanyProductStockSerialMap>> GetAsync(Expression<Func<CompanyProductStockSerialMap, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductStockSerialMaps.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProductStockSerialMap>.NotFound();
            return Result<CompanyProductStockSerialMap>.Success(result);
        }

        public async Task<Result<CompanyProductStockSerialMap>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductStockSerialMaps.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProductStockSerialMap>.NotFound();
            return Result<CompanyProductStockSerialMap>.Success(result);
        }

        public async Task<Result<CompanyProductStockSerialMapDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductStockSerialMaps.GetAsync<CompanyProductStockSerialMapDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProductStockSerialMapDto>.NotFound();
            return Result<CompanyProductStockSerialMapDto>.Success(result);
        }

        public async Task<Result<ICollection<CompanyProductStockSerialMap>>> GetListAsync(Expression<Func<CompanyProductStockSerialMap, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductStockSerialMaps.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyProductStockSerialMap>>.NotFound();
            return Result<ICollection<CompanyProductStockSerialMap>>.Success(result);
        }

        public async Task<Result<ICollection<CompanyProductStockSerialMap>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductStockSerialMaps.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyProductStockSerialMap>>.NotFound();
            return Result<ICollection<CompanyProductStockSerialMap>>.Success(result);
        }

        public async Task<Result<ICollection<CompanyProductStockSerialMapDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductStockSerialMaps.GetAllAsync<CompanyProductStockSerialMapDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyProductStockSerialMapDto>>.NotFound();
            return Result<ICollection<CompanyProductStockSerialMapDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(CompanyProductStockSerialMapCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for CompanyProductStockSerialMapCreateDto");
            await _unitOfWork.CompanyProductStockSerialMaps.AddAndSaveAsync(_mapper.Map<CompanyProductStockSerialMap>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<CompanyProductStockSerialMapUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductStockSerialMaps.GetAsync<CompanyProductStockSerialMapUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProductStockSerialMapUpdateDto>.NotFound();
            return Result<CompanyProductStockSerialMapUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(CompanyProductStockSerialMapUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.CompanyProductStockSerialMaps.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.CompanyProductStockSerialMaps.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.CompanyProductStockSerialMaps.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<CompanyProductStockSerialMap>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductStockSerialMaps.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<CompanyProductStockSerialMap>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<CompanyProductStockSerialMap>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductStockSerialMaps.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<CompanyProductStockSerialMap>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<CompanyProductStockSerialMap>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductStockSerialMaps.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<CompanyProductStockSerialMap>>.Success(result);
        }
    }
}