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
using ExpressDesk360.Model.Dtos.WarrantyType.Commands;
using ExpressDesk360.Model.Dtos.WarrantyType.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class WarrantyTypeService : IWarrantyTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public WarrantyTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<WarrantyType>> GetAsync(Expression<Func<WarrantyType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.WarrantyTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<WarrantyType>.NotFound();
            return Result<WarrantyType>.Success(result);
        }

        public async Task<Result<WarrantyType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.WarrantyTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<WarrantyType>.NotFound();
            return Result<WarrantyType>.Success(result);
        }

        public async Task<Result<WarrantyTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.WarrantyTypes.GetAsync<WarrantyTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<WarrantyTypeDto>.NotFound();
            return Result<WarrantyTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<WarrantyType>>> GetListAsync(Expression<Func<WarrantyType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.WarrantyTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<WarrantyType>>.NotFound();
            return Result<ICollection<WarrantyType>>.Success(result);
        }

        public async Task<Result<ICollection<WarrantyType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.WarrantyTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<WarrantyType>>.NotFound();
            return Result<ICollection<WarrantyType>>.Success(result);
        }

        public async Task<Result<ICollection<WarrantyTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.WarrantyTypes.GetAllAsync<WarrantyTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<WarrantyTypeDto>>.NotFound();
            return Result<ICollection<WarrantyTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<WarrantyType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.WarrantyTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(WarrantyTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for WarrantyTypeCreateDto");
            await _unitOfWork.WarrantyTypes.AddAndSaveAsync(_mapper.Map<WarrantyType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<WarrantyTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.WarrantyTypes.GetAsync<WarrantyTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<WarrantyTypeUpdateDto>.NotFound();
            return Result<WarrantyTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(WarrantyTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.WarrantyTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.WarrantyTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.WarrantyTypes.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.WarrantyTypes.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<WarrantyType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.WarrantyTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<WarrantyType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<WarrantyType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.WarrantyTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<WarrantyType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<WarrantyType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.WarrantyTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<WarrantyType>>.Success(result);
        }
    }
}