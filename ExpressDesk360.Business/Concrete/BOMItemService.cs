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
using ExpressDesk360.Model.Dtos.BOMItem.Commands;
using ExpressDesk360.Model.Dtos.BOMItem.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class BOMItemService : IBOMItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public BOMItemService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<BOMItem>> GetAsync(Expression<Func<BOMItem, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMItems.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<BOMItem>.NotFound();
            return Result<BOMItem>.Success(result);
        }

        public async Task<Result<BOMItem>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMItems.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<BOMItem>.NotFound();
            return Result<BOMItem>.Success(result);
        }

        public async Task<Result<BOMItemDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMItems.GetAsync<BOMItemDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<BOMItemDto>.NotFound();
            return Result<BOMItemDto>.Success(result);
        }

        public async Task<Result<ICollection<BOMItem>>> GetListAsync(Expression<Func<BOMItem, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMItems.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<BOMItem>>.NotFound();
            return Result<ICollection<BOMItem>>.Success(result);
        }

        public async Task<Result<ICollection<BOMItem>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMItems.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<BOMItem>>.NotFound();
            return Result<ICollection<BOMItem>>.Success(result);
        }

        public async Task<Result<ICollection<BOMItemDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMItems.GetAllAsync<BOMItemDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<BOMItemDto>>.NotFound();
            return Result<ICollection<BOMItemDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(BOMItemCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for BOMItemCreateDto");
            await _unitOfWork.BOMItems.AddAndSaveAsync(_mapper.Map<BOMItem>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<BOMItemUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMItems.GetAsync<BOMItemUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<BOMItemUpdateDto>.NotFound();
            return Result<BOMItemUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(BOMItemUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.BOMItems.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.BOMItems.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.BOMItems.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.BOMItems.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<BOMItem>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMItems.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<BOMItem>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<BOMItem>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMItems.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<BOMItem>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<BOMItem>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMItems.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<BOMItem>>.Success(result);
        }
    }
}