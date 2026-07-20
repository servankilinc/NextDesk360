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
using ExpressDesk360.Model.Dtos.TicketMessage.Commands;
using ExpressDesk360.Model.Dtos.TicketMessage.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class TicketMessageService : ITicketMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public TicketMessageService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TicketMessage>> GetAsync(Expression<Func<TicketMessage, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessages.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMessage>.NotFound();
            return Result<TicketMessage>.Success(result);
        }

        public async Task<Result<TicketMessage>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessages.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMessage>.NotFound();
            return Result<TicketMessage>.Success(result);
        }

        public async Task<Result<TicketMessageDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessages.GetAsync<TicketMessageDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMessageDto>.NotFound();
            return Result<TicketMessageDto>.Success(result);
        }

        public async Task<Result<ICollection<TicketMessage>>> GetListAsync(Expression<Func<TicketMessage, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessages.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMessage>>.NotFound();
            return Result<ICollection<TicketMessage>>.Success(result);
        }

        public async Task<Result<ICollection<TicketMessage>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessages.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMessage>>.NotFound();
            return Result<ICollection<TicketMessage>>.Success(result);
        }

        public async Task<Result<ICollection<TicketMessageDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessages.GetAllAsync<TicketMessageDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMessageDto>>.NotFound();
            return Result<ICollection<TicketMessageDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketMessage, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.TicketMessages.GetAllAsync<object>(select: s => new { s.Id, s.Content }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Content");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TicketMessageCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TicketMessageCreateDto");
            await _unitOfWork.TicketMessages.AddAndSaveAsync(_mapper.Map<TicketMessage>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TicketMessageUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessages.GetAsync<TicketMessageUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMessageUpdateDto>.NotFound();
            return Result<TicketMessageUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TicketMessageUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.TicketMessages.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.TicketMessages.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.TicketMessages.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.TicketMessages.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<TicketMessage>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessages.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TicketMessage>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TicketMessage>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessages.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TicketMessage>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TicketMessage>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessages.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TicketMessage>>.Success(result);
        }
    }
}