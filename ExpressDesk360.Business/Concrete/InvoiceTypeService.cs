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
using ExpressDesk360.Model.Dtos.InvoiceType.Commands;
using ExpressDesk360.Model.Dtos.InvoiceType.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class InvoiceTypeService : IInvoiceTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public InvoiceTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<InvoiceType>> GetAsync(Expression<Func<InvoiceType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.InvoiceTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<InvoiceType>.NotFound();
            return Result<InvoiceType>.Success(result);
        }

        public async Task<Result<InvoiceType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.InvoiceTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<InvoiceType>.NotFound();
            return Result<InvoiceType>.Success(result);
        }

        public async Task<Result<InvoiceTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.InvoiceTypes.GetAsync<InvoiceTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<InvoiceTypeDto>.NotFound();
            return Result<InvoiceTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<InvoiceType>>> GetListAsync(Expression<Func<InvoiceType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.InvoiceTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<InvoiceType>>.NotFound();
            return Result<ICollection<InvoiceType>>.Success(result);
        }

        public async Task<Result<ICollection<InvoiceType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.InvoiceTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<InvoiceType>>.NotFound();
            return Result<ICollection<InvoiceType>>.Success(result);
        }

        public async Task<Result<ICollection<InvoiceTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.InvoiceTypes.GetAllAsync<InvoiceTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<InvoiceTypeDto>>.NotFound();
            return Result<ICollection<InvoiceTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<InvoiceType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.InvoiceTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(InvoiceTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for InvoiceTypeCreateDto");
            await _unitOfWork.InvoiceTypes.AddAndSaveAsync(_mapper.Map<InvoiceType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<InvoiceTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.InvoiceTypes.GetAsync<InvoiceTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<InvoiceTypeUpdateDto>.NotFound();
            return Result<InvoiceTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(InvoiceTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.InvoiceTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.InvoiceTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.InvoiceTypes.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.InvoiceTypes.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<InvoiceType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.InvoiceTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<InvoiceType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<InvoiceType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.InvoiceTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<InvoiceType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<InvoiceType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.InvoiceTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<InvoiceType>>.Success(result);
        }
    }
}