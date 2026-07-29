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
using ExpressDesk360.Model.Dtos.Currency.Commands;
using ExpressDesk360.Model.Dtos.Currency.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public CurrencyService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<Currency>> GetAsync(Expression<Func<Currency, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Currencies.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Currency>.NotFound();
            return Result<Currency>.Success(result);
        }

        public async Task<Result<Currency>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Currencies.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Currency>.NotFound();
            return Result<Currency>.Success(result);
        }

        public async Task<Result<CurrencyDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Currencies.GetAsync<CurrencyDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CurrencyDto>.NotFound();
            return Result<CurrencyDto>.Success(result);
        }

        public async Task<Result<ICollection<Currency>>> GetListAsync(Expression<Func<Currency, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Currencies.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Currency>>.NotFound();
            return Result<ICollection<Currency>>.Success(result);
        }

        public async Task<Result<ICollection<Currency>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Currencies.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Currency>>.NotFound();
            return Result<ICollection<Currency>>.Success(result);
        }

        public async Task<Result<ICollection<CurrencyDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Currencies.GetAllAsync<CurrencyDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CurrencyDto>>.NotFound();
            return Result<ICollection<CurrencyDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<Currency, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.Currencies.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(CurrencyCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for CurrencyCreateDto");
            await _unitOfWork.Currencies.AddAndSaveAsync(_mapper.Map<Currency>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<CurrencyUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Currencies.GetAsync<CurrencyUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CurrencyUpdateDto>.NotFound();
            return Result<CurrencyUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(CurrencyUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.Currencies.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.Currencies.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<Currency>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Currencies.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<Currency>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<Currency>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Currencies.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<Currency>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<Currency>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Currencies.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<Currency>>.Success(result);
        }
    }
}
