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
using ExpressDesk360.Model.Dtos.TicketPriority.Commands;
using ExpressDesk360.Model.Dtos.TicketPriority.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class TicketPriorityService : ITicketPriorityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public TicketPriorityService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TicketPriority>> GetAsync(Expression<Func<TicketPriority, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketPriorities.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketPriority>.NotFound();
            return Result<TicketPriority>.Success(result);
        }

        public async Task<Result<TicketPriority>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketPriorities.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketPriority>.NotFound();
            return Result<TicketPriority>.Success(result);
        }

        public async Task<Result<TicketPriorityDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketPriorities.GetAsync<TicketPriorityDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketPriorityDto>.NotFound();
            return Result<TicketPriorityDto>.Success(result);
        }

        public async Task<Result<ICollection<TicketPriority>>> GetListAsync(Expression<Func<TicketPriority, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketPriorities.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketPriority>>.NotFound();
            return Result<ICollection<TicketPriority>>.Success(result);
        }

        public async Task<Result<ICollection<TicketPriority>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketPriorities.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketPriority>>.NotFound();
            return Result<ICollection<TicketPriority>>.Success(result);
        }

        public async Task<Result<ICollection<TicketPriorityDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketPriorities.GetAllAsync<TicketPriorityDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketPriorityDto>>.NotFound();
            return Result<ICollection<TicketPriorityDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketPriority, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.TicketPriorities.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TicketPriorityCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TicketPriorityCreateDto");
            await _unitOfWork.TicketPriorities.AddAndSaveAsync(_mapper.Map<TicketPriority>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TicketPriorityUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketPriorities.GetAsync<TicketPriorityUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketPriorityUpdateDto>.NotFound();
            return Result<TicketPriorityUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TicketPriorityUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.TicketPriorities.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.TicketPriorities.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.TicketPriorities.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.TicketPriorities.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<TicketPriority>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketPriorities.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TicketPriority>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TicketPriority>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketPriorities.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TicketPriority>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TicketPriority>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketPriorities.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TicketPriority>>.Success(result);
        }
    }
}