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
using ExpressDesk360.Model.Dtos.StockSerialWarranty.Commands;
using ExpressDesk360.Model.Dtos.StockSerialWarranty.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class StockSerialWarrantyService : IStockSerialWarrantyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockSerialWarrantyService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockSerialWarranty>> GetAsync(Expression<Func<StockSerialWarranty, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerialWarranties.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockSerialWarranty>.NotFound();
            return Result<StockSerialWarranty>.Success(result);
        }

        public async Task<Result<StockSerialWarranty>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerialWarranties.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockSerialWarranty>.NotFound();
            return Result<StockSerialWarranty>.Success(result);
        }

        public async Task<Result<StockSerialWarrantyDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerialWarranties.GetAsync<StockSerialWarrantyDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockSerialWarrantyDto>.NotFound();
            return Result<StockSerialWarrantyDto>.Success(result);
        }

        public async Task<Result<ICollection<StockSerialWarranty>>> GetListAsync(Expression<Func<StockSerialWarranty, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerialWarranties.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockSerialWarranty>>.NotFound();
            return Result<ICollection<StockSerialWarranty>>.Success(result);
        }

        public async Task<Result<ICollection<StockSerialWarranty>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerialWarranties.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockSerialWarranty>>.NotFound();
            return Result<ICollection<StockSerialWarranty>>.Success(result);
        }

        public async Task<Result<ICollection<StockSerialWarrantyDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerialWarranties.GetAllAsync<StockSerialWarrantyDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockSerialWarrantyDto>>.NotFound();
            return Result<ICollection<StockSerialWarrantyDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(StockSerialWarrantyCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockSerialWarrantyCreateDto");
            await _unitOfWork.StockSerialWarranties.AddAndSaveAsync(_mapper.Map<StockSerialWarranty>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockSerialWarrantyUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerialWarranties.GetAsync<StockSerialWarrantyUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockSerialWarrantyUpdateDto>.NotFound();
            return Result<StockSerialWarrantyUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockSerialWarrantyUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.StockSerialWarranties.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.StockSerialWarranties.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.StockSerialWarranties.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.StockSerialWarranties.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<StockSerialWarranty>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerialWarranties.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockSerialWarranty>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockSerialWarranty>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerialWarranties.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockSerialWarranty>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockSerialWarranty>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerialWarranties.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockSerialWarranty>>.Success(result);
        }
    }
}