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
using ExpressDesk360.Model.Dtos.ShippingType.Commands;
using ExpressDesk360.Model.Dtos.ShippingType.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class ShippingTypeService : IShippingTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public ShippingTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<ShippingType>> GetAsync(Expression<Func<ShippingType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ShippingType>.NotFound();
            return Result<ShippingType>.Success(result);
        }

        public async Task<Result<ShippingType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ShippingType>.NotFound();
            return Result<ShippingType>.Success(result);
        }

        public async Task<Result<ShippingTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingTypes.GetAsync<ShippingTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ShippingTypeDto>.NotFound();
            return Result<ShippingTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<ShippingType>>> GetListAsync(Expression<Func<ShippingType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ShippingType>>.NotFound();
            return Result<ICollection<ShippingType>>.Success(result);
        }

        public async Task<Result<ICollection<ShippingType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ShippingType>>.NotFound();
            return Result<ICollection<ShippingType>>.Success(result);
        }

        public async Task<Result<ICollection<ShippingTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingTypes.GetAllAsync<ShippingTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ShippingTypeDto>>.NotFound();
            return Result<ICollection<ShippingTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<ShippingType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.ShippingTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(ShippingTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for ShippingTypeCreateDto");
            await _unitOfWork.ShippingTypes.AddAndSaveAsync(_mapper.Map<ShippingType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<ShippingTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingTypes.GetAsync<ShippingTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ShippingTypeUpdateDto>.NotFound();
            return Result<ShippingTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(ShippingTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.ShippingTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.ShippingTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.ShippingTypes.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.ShippingTypes.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<ShippingType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<ShippingType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<ShippingType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<ShippingType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<ShippingType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<ShippingType>>.Success(result);
        }
    }
}