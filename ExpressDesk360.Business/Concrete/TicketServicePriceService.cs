using AutoMapper;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Core.Utils.Validation;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.UoW;
using ExpressDesk360.Model.Dtos.TicketModule.TicketServicePrice.Commands;
using ExpressDesk360.Model.Dtos.TicketModule.TicketServicePrice.Queries;
using ExpressDesk360.Model.Entities.TicketModule;
using ExpressDesk360.Business.Abstract.TicketModule;

namespace ExpressDesk360.Business.Concrete
{
    public class TicketServicePriceService : ITicketServicePriceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public TicketServicePriceService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TicketServicePrice>> GetAsync(Expression<Func<TicketServicePrice, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketServicePrices.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketServicePrice>.NotFound();
            return Result<TicketServicePrice>.Success(result);
        }

        public async Task<Result<TicketServicePrice>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketServicePrices.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketServicePrice>.NotFound();
            return Result<TicketServicePrice>.Success(result);
        }

        public async Task<Result<TicketServicePriceDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketServicePrices.GetAsync<TicketServicePriceDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketServicePriceDto>.NotFound();
            return Result<TicketServicePriceDto>.Success(result);
        }

        public async Task<Result<ICollection<TicketServicePrice>>> GetListAsync(Expression<Func<TicketServicePrice, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketServicePrices.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketServicePrice>>.NotFound();
            return Result<ICollection<TicketServicePrice>>.Success(result);
        }

        public async Task<Result<ICollection<TicketServicePrice>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketServicePrices.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketServicePrice>>.NotFound();
            return Result<ICollection<TicketServicePrice>>.Success(result);
        }

        public async Task<Result<ICollection<TicketServicePriceDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketServicePrices.GetAllAsync<TicketServicePriceDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketServicePriceDto>>.NotFound();
            return Result<ICollection<TicketServicePriceDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketServicePrice, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.TicketServicePrices.GetAllAsync<object>(select: s => new { s.Id, s.ServiceDescription }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "ServiceDescription");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TicketServicePriceCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TicketServicePriceCreateDto");
            await _unitOfWork.TicketServicePrices.AddAndSaveAsync(_mapper.Map<TicketServicePrice>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TicketServicePriceUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketServicePrices.GetAsync<TicketServicePriceUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketServicePriceUpdateDto>.NotFound();
            return Result<TicketServicePriceUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TicketServicePriceUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.TicketServicePrices.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.TicketServicePrices.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.TicketServicePrices.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.TicketServicePrices.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<TicketServicePrice>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketServicePrices.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TicketServicePrice>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TicketServicePrice>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketServicePrices.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TicketServicePrice>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TicketServicePrice>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketServicePrices.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TicketServicePrice>>.Success(result);
        }
    }
}