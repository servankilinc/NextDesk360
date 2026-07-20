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
using ExpressDesk360.Model.Dtos.CompanyProductWarranty.Commands;
using ExpressDesk360.Model.Dtos.CompanyProductWarranty.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class CompanyProductWarrantyService : ICompanyProductWarrantyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public CompanyProductWarrantyService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<CompanyProductWarranty>> GetAsync(Expression<Func<CompanyProductWarranty, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductWarranties.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProductWarranty>.NotFound();
            return Result<CompanyProductWarranty>.Success(result);
        }

        public async Task<Result<CompanyProductWarranty>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductWarranties.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProductWarranty>.NotFound();
            return Result<CompanyProductWarranty>.Success(result);
        }

        public async Task<Result<CompanyProductWarrantyDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductWarranties.GetAsync<CompanyProductWarrantyDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProductWarrantyDto>.NotFound();
            return Result<CompanyProductWarrantyDto>.Success(result);
        }

        public async Task<Result<ICollection<CompanyProductWarranty>>> GetListAsync(Expression<Func<CompanyProductWarranty, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductWarranties.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyProductWarranty>>.NotFound();
            return Result<ICollection<CompanyProductWarranty>>.Success(result);
        }

        public async Task<Result<ICollection<CompanyProductWarranty>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductWarranties.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyProductWarranty>>.NotFound();
            return Result<ICollection<CompanyProductWarranty>>.Success(result);
        }

        public async Task<Result<ICollection<CompanyProductWarrantyDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductWarranties.GetAllAsync<CompanyProductWarrantyDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyProductWarrantyDto>>.NotFound();
            return Result<ICollection<CompanyProductWarrantyDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(CompanyProductWarrantyCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for CompanyProductWarrantyCreateDto");
            await _unitOfWork.CompanyProductWarranties.AddAndSaveAsync(_mapper.Map<CompanyProductWarranty>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<CompanyProductWarrantyUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductWarranties.GetAsync<CompanyProductWarrantyUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyProductWarrantyUpdateDto>.NotFound();
            return Result<CompanyProductWarrantyUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(CompanyProductWarrantyUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.CompanyProductWarranties.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.CompanyProductWarranties.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.CompanyProductWarranties.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.CompanyProductWarranties.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<CompanyProductWarranty>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductWarranties.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<CompanyProductWarranty>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<CompanyProductWarranty>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductWarranties.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<CompanyProductWarranty>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<CompanyProductWarranty>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyProductWarranties.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<CompanyProductWarranty>>.Success(result);
        }
    }
}