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
using ExpressDesk360.Model.Dtos.StockGroupFaultTypeMap.Commands;
using ExpressDesk360.Model.Dtos.StockGroupFaultTypeMap.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class StockGroupFaultTypeMapService : IStockGroupFaultTypeMapService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockGroupFaultTypeMapService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockGroupFaultTypeMap>> GetAsync(Expression<Func<StockGroupFaultTypeMap, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupFaultTypeMaps.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupFaultTypeMap>.NotFound();
            return Result<StockGroupFaultTypeMap>.Success(result);
        }

        public async Task<Result<StockGroupFaultTypeMap>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupFaultTypeMaps.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupFaultTypeMap>.NotFound();
            return Result<StockGroupFaultTypeMap>.Success(result);
        }

        public async Task<Result<StockGroupFaultTypeMapDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupFaultTypeMaps.GetAsync<StockGroupFaultTypeMapDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupFaultTypeMapDto>.NotFound();
            return Result<StockGroupFaultTypeMapDto>.Success(result);
        }

        public async Task<Result<ICollection<StockGroupFaultTypeMap>>> GetListAsync(Expression<Func<StockGroupFaultTypeMap, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupFaultTypeMaps.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroupFaultTypeMap>>.NotFound();
            return Result<ICollection<StockGroupFaultTypeMap>>.Success(result);
        }

        public async Task<Result<ICollection<StockGroupFaultTypeMap>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupFaultTypeMaps.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroupFaultTypeMap>>.NotFound();
            return Result<ICollection<StockGroupFaultTypeMap>>.Success(result);
        }

        public async Task<Result<ICollection<StockGroupFaultTypeMapDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupFaultTypeMaps.GetAllAsync<StockGroupFaultTypeMapDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroupFaultTypeMapDto>>.NotFound();
            return Result<ICollection<StockGroupFaultTypeMapDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(StockGroupFaultTypeMapCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockGroupFaultTypeMapCreateDto");
            await _unitOfWork.StockGroupFaultTypeMaps.AddAndSaveAsync(_mapper.Map<StockGroupFaultTypeMap>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockGroupFaultTypeMapUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupFaultTypeMaps.GetAsync<StockGroupFaultTypeMapUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupFaultTypeMapUpdateDto>.NotFound();
            return Result<StockGroupFaultTypeMapUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockGroupFaultTypeMapUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.StockGroupFaultTypeMaps.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.StockGroupFaultTypeMaps.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.StockGroupFaultTypeMaps.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<StockGroupFaultTypeMap>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupFaultTypeMaps.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockGroupFaultTypeMap>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockGroupFaultTypeMap>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupFaultTypeMaps.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockGroupFaultTypeMap>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockGroupFaultTypeMap>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupFaultTypeMaps.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockGroupFaultTypeMap>>.Success(result);
        }
    }
}