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
using ExpressDesk360.Model.Dtos.StockModule.StockTypeGroupMap.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockTypeGroupMap.Queries;
using ExpressDesk360.Business.Abstract.StockModule;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Concrete.StockModule
{
    public class StockTypeGroupMapService : IStockTypeGroupMapService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockTypeGroupMapService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockTypeGroupMap>> GetAsync(Expression<Func<StockTypeGroupMap, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypeGroupMaps.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockTypeGroupMap>.NotFound();
            return Result<StockTypeGroupMap>.Success(result);
        }

        public async Task<Result<StockTypeGroupMap>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypeGroupMaps.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockTypeGroupMap>.NotFound();
            return Result<StockTypeGroupMap>.Success(result);
        }

        public async Task<Result<StockTypeGroupMapDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypeGroupMaps.GetAsync<StockTypeGroupMapDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockTypeGroupMapDto>.NotFound();
            return Result<StockTypeGroupMapDto>.Success(result);
        }

        public async Task<Result<ICollection<StockTypeGroupMap>>> GetListAsync(Expression<Func<StockTypeGroupMap, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypeGroupMaps.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockTypeGroupMap>>.NotFound();
            return Result<ICollection<StockTypeGroupMap>>.Success(result);
        }

        public async Task<Result<ICollection<StockTypeGroupMap>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypeGroupMaps.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockTypeGroupMap>>.NotFound();
            return Result<ICollection<StockTypeGroupMap>>.Success(result);
        }

        public async Task<Result<ICollection<StockTypeGroupMapDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypeGroupMaps.GetAllAsync<StockTypeGroupMapDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockTypeGroupMapDto>>.NotFound();
            return Result<ICollection<StockTypeGroupMapDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(StockTypeGroupMapCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockTypeGroupMapCreateDto");
            await _unitOfWork.StockTypeGroupMaps.AddAndSaveAsync(_mapper.Map<StockTypeGroupMap>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockTypeGroupMapUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypeGroupMaps.GetAsync<StockTypeGroupMapUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockTypeGroupMapUpdateDto>.NotFound();
            return Result<StockTypeGroupMapUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockTypeGroupMapUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.StockTypeGroupMaps.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.StockTypeGroupMaps.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.StockTypeGroupMaps.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<StockTypeGroupMap>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypeGroupMaps.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockTypeGroupMap>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockTypeGroupMap>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypeGroupMaps.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockTypeGroupMap>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockTypeGroupMap>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypeGroupMaps.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockTypeGroupMap>>.Success(result);
        }
    }
}