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
using ExpressDesk360.Model.Dtos.Shipping.Commands;
using ExpressDesk360.Model.Dtos.Shipping.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class ShippingService : IShippingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public ShippingService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<Shipping>> GetAsync(Expression<Func<Shipping, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Shippings.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Shipping>.NotFound();
            return Result<Shipping>.Success(result);
        }

        public async Task<Result<Shipping>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Shippings.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Shipping>.NotFound();
            return Result<Shipping>.Success(result);
        }

        public async Task<Result<ShippingDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Shippings.GetAsync<ShippingDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ShippingDto>.NotFound();
            return Result<ShippingDto>.Success(result);
        }

        public async Task<Result<ICollection<Shipping>>> GetListAsync(Expression<Func<Shipping, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Shippings.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Shipping>>.NotFound();
            return Result<ICollection<Shipping>>.Success(result);
        }

        public async Task<Result<ICollection<Shipping>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Shippings.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Shipping>>.NotFound();
            return Result<ICollection<Shipping>>.Success(result);
        }

        public async Task<Result<ICollection<ShippingDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Shippings.GetAllAsync<ShippingDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ShippingDto>>.NotFound();
            return Result<ICollection<ShippingDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<Shipping, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.Shippings.GetAllAsync<object>(select: s => new { s.Id, s.SendingCompanyName }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "SendingCompanyName");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(ShippingCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for ShippingCreateDto");
            await _unitOfWork.Shippings.AddAndSaveAsync(_mapper.Map<Shipping>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<ShippingUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Shippings.GetAsync<ShippingUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ShippingUpdateDto>.NotFound();
            return Result<ShippingUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(ShippingUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.Shippings.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.Shippings.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Shippings.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Shippings.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<Shipping>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Shippings.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<Shipping>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<Shipping>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Shippings.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<Shipping>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<Shipping>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Shippings.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<Shipping>>.Success(result);
        }
    }
}