using AutoMapper;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Core.Utils.Validation;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.UoW;
using ExpressDesk360.Model.Dtos.StockModule.StockMovementStockSerialMap.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockMovementStockSerialMap.Queries;
using ExpressDesk360.Business.Abstract.StockModule;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Concrete.StockModule
{
    public class StockMovementStockSerialMapService : IStockMovementStockSerialMapService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockMovementStockSerialMapService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockMovementStockSerialMap>> GetAsync(Expression<Func<StockMovementStockSerialMap, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementStockSerialMaps.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovementStockSerialMap>.NotFound();
            return Result<StockMovementStockSerialMap>.Success(result);
        }

        public async Task<Result<StockMovementStockSerialMap>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementStockSerialMaps.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovementStockSerialMap>.NotFound();
            return Result<StockMovementStockSerialMap>.Success(result);
        }

        public async Task<Result<StockMovementStockSerialMapDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementStockSerialMaps.GetAsync<StockMovementStockSerialMapDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovementStockSerialMapDto>.NotFound();
            return Result<StockMovementStockSerialMapDto>.Success(result);
        }

        public async Task<Result<ICollection<StockMovementStockSerialMap>>> GetListAsync(Expression<Func<StockMovementStockSerialMap, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementStockSerialMaps.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockMovementStockSerialMap>>.NotFound();
            return Result<ICollection<StockMovementStockSerialMap>>.Success(result);
        }

        public async Task<Result<ICollection<StockMovementStockSerialMap>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementStockSerialMaps.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockMovementStockSerialMap>>.NotFound();
            return Result<ICollection<StockMovementStockSerialMap>>.Success(result);
        }

        public async Task<Result<ICollection<StockMovementStockSerialMapDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementStockSerialMaps.GetAllAsync<StockMovementStockSerialMapDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockMovementStockSerialMapDto>>.NotFound();
            return Result<ICollection<StockMovementStockSerialMapDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(StockMovementStockSerialMapCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockMovementStockSerialMapCreateDto");
            await _unitOfWork.StockMovementStockSerialMaps.AddAndSaveAsync(_mapper.Map<StockMovementStockSerialMap>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockMovementStockSerialMapUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementStockSerialMaps.GetAsync<StockMovementStockSerialMapUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovementStockSerialMapUpdateDto>.NotFound();
            return Result<StockMovementStockSerialMapUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockMovementStockSerialMapUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.StockMovementStockSerialMaps.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.StockMovementStockSerialMaps.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.StockMovementStockSerialMaps.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<StockMovementStockSerialMap>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementStockSerialMaps.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockMovementStockSerialMap>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockMovementStockSerialMap>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementStockSerialMaps.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockMovementStockSerialMap>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockMovementStockSerialMap>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementStockSerialMaps.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockMovementStockSerialMap>>.Success(result);
        }
    }
}