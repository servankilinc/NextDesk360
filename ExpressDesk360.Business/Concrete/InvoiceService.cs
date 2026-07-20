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
using ExpressDesk360.Model.Dtos.Invoice.Commands;
using ExpressDesk360.Model.Dtos.Invoice.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public InvoiceService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<Invoice>> GetAsync(Expression<Func<Invoice, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Invoices.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Invoice>.NotFound();
            return Result<Invoice>.Success(result);
        }

        public async Task<Result<Invoice>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Invoices.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Invoice>.NotFound();
            return Result<Invoice>.Success(result);
        }

        public async Task<Result<InvoiceDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Invoices.GetAsync<InvoiceDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<InvoiceDto>.NotFound();
            return Result<InvoiceDto>.Success(result);
        }

        public async Task<Result<ICollection<Invoice>>> GetListAsync(Expression<Func<Invoice, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Invoices.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Invoice>>.NotFound();
            return Result<ICollection<Invoice>>.Success(result);
        }

        public async Task<Result<ICollection<Invoice>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Invoices.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Invoice>>.NotFound();
            return Result<ICollection<Invoice>>.Success(result);
        }

        public async Task<Result<ICollection<InvoiceDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Invoices.GetAllAsync<InvoiceDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<InvoiceDto>>.NotFound();
            return Result<ICollection<InvoiceDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<Invoice, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.Invoices.GetAllAsync<object>(select: s => new { s.Id, s.InvoiceNo }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "InvoiceNo");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(InvoiceCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for InvoiceCreateDto");
            await _unitOfWork.Invoices.AddAndSaveAsync(_mapper.Map<Invoice>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<InvoiceUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Invoices.GetAsync<InvoiceUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<InvoiceUpdateDto>.NotFound();
            return Result<InvoiceUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(InvoiceUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.Invoices.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.Invoices.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Invoices.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Invoices.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<Invoice>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Invoices.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<Invoice>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<Invoice>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Invoices.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<Invoice>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<Invoice>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Invoices.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<Invoice>>.Success(result);
        }
    }
}