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
using ExpressDesk360.Model.Dtos.StockGroupBrandMap.Commands;
using ExpressDesk360.Model.Dtos.StockGroupBrandMap.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class StockGroupBrandMapService : IStockGroupBrandMapService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockGroupBrandMapService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockGroupBrandMap>> GetAsync(Expression<Func<StockGroupBrandMap, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupBrandMaps.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupBrandMap>.NotFound();
            return Result<StockGroupBrandMap>.Success(result);
        }

        public async Task<Result<StockGroupBrandMap>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupBrandMaps.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupBrandMap>.NotFound();
            return Result<StockGroupBrandMap>.Success(result);
        }

        public async Task<Result<StockGroupBrandMapDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupBrandMaps.GetAsync<StockGroupBrandMapDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupBrandMapDto>.NotFound();
            return Result<StockGroupBrandMapDto>.Success(result);
        }

        public async Task<Result<ICollection<StockGroupBrandMap>>> GetListAsync(Expression<Func<StockGroupBrandMap, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupBrandMaps.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroupBrandMap>>.NotFound();
            return Result<ICollection<StockGroupBrandMap>>.Success(result);
        }

        public async Task<Result<ICollection<StockGroupBrandMap>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupBrandMaps.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroupBrandMap>>.NotFound();
            return Result<ICollection<StockGroupBrandMap>>.Success(result);
        }

        public async Task<Result<ICollection<StockGroupBrandMapDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupBrandMaps.GetAllAsync<StockGroupBrandMapDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroupBrandMapDto>>.NotFound();
            return Result<ICollection<StockGroupBrandMapDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(StockGroupBrandMapCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockGroupBrandMapCreateDto");
            await _unitOfWork.StockGroupBrandMaps.AddAndSaveAsync(_mapper.Map<StockGroupBrandMap>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockGroupBrandMapUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupBrandMaps.GetAsync<StockGroupBrandMapUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupBrandMapUpdateDto>.NotFound();
            return Result<StockGroupBrandMapUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockGroupBrandMapUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.StockGroupBrandMaps.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.StockGroupBrandMaps.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.StockGroupBrandMaps.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.StockGroupBrandMaps.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<StockGroupBrandMap>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupBrandMaps.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockGroupBrandMap>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockGroupBrandMap>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupBrandMaps.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockGroupBrandMap>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockGroupBrandMap>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroupBrandMaps.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockGroupBrandMap>>.Success(result);
        }
    }
}