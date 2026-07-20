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
using ExpressDesk360.Model.Dtos.CompanyProduct.Commands;
using ExpressDesk360.Model.Dtos.CompanyProduct.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class CompanyProductService : ICompanyProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public CompanyProductService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<CompanyProduct>> GetAsync(Expression<Func<CompanyProduct, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProducts.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProduct>.NotFound();
            return Result<CompanyProduct>.Success(result);
        }

        public async Task<Result<CompanyProduct>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProducts.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProduct>.NotFound();
            return Result<CompanyProduct>.Success(result);
        }

        public async Task<Result<CompanyProductDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProducts.GetAsync<CompanyProductDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProductDto>.NotFound();
            return Result<CompanyProductDto>.Success(result);
        }

        public async Task<Result<ICollection<CompanyProduct>>> GetListAsync(Expression<Func<CompanyProduct, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProducts.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyProduct>>.NotFound();
            return Result<ICollection<CompanyProduct>>.Success(result);
        }

        public async Task<Result<ICollection<CompanyProduct>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProducts.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyProduct>>.NotFound();
            return Result<ICollection<CompanyProduct>>.Success(result);
        }

        public async Task<Result<ICollection<CompanyProductDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProducts.GetAllAsync<CompanyProductDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyProductDto>>.NotFound();
            return Result<ICollection<CompanyProductDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<CompanyProduct, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.CompanyProducts.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(CompanyProductCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for CompanyProductCreateDto");
            await _unitOfWork.CompanyProducts.AddAndSaveAsync(_mapper.Map<CompanyProduct>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<CompanyProductUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProducts.GetAsync<CompanyProductUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProductUpdateDto>.NotFound();
            return Result<CompanyProductUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(CompanyProductUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.CompanyProducts.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.CompanyProducts.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.CompanyProducts.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.CompanyProducts.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<CompanyProduct>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProducts.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<CompanyProduct>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<CompanyProduct>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProducts.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<CompanyProduct>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<CompanyProduct>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProducts.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<CompanyProduct>>.Success(result);
        }
    }
}