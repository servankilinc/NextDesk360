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
using ExpressDesk360.Model.Dtos.TicketStatus.Commands;
using ExpressDesk360.Model.Dtos.TicketStatus.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class TicketStatusService : ITicketStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public TicketStatusService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TicketStatus>> GetAsync(Expression<Func<TicketStatus, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStatuses.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketStatus>.NotFound();
            return Result<TicketStatus>.Success(result);
        }

        public async Task<Result<TicketStatus>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStatuses.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketStatus>.NotFound();
            return Result<TicketStatus>.Success(result);
        }

        public async Task<Result<TicketStatusDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStatuses.GetAsync<TicketStatusDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketStatusDto>.NotFound();
            return Result<TicketStatusDto>.Success(result);
        }

        public async Task<Result<ICollection<TicketStatus>>> GetListAsync(Expression<Func<TicketStatus, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStatuses.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketStatus>>.NotFound();
            return Result<ICollection<TicketStatus>>.Success(result);
        }

        public async Task<Result<ICollection<TicketStatus>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStatuses.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketStatus>>.NotFound();
            return Result<ICollection<TicketStatus>>.Success(result);
        }

        public async Task<Result<ICollection<TicketStatusDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStatuses.GetAllAsync<TicketStatusDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketStatusDto>>.NotFound();
            return Result<ICollection<TicketStatusDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketStatus, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.TicketStatuses.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TicketStatusCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TicketStatusCreateDto");
            await _unitOfWork.TicketStatuses.AddAndSaveAsync(_mapper.Map<TicketStatus>(request), cancellationToken);
            return Result.Success();
        }





        public async Task<Result<PaginationResponse<TicketStatus>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStatuses.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TicketStatus>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TicketStatus>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStatuses.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TicketStatus>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TicketStatus>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStatuses.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TicketStatus>>.Success(result);
        }
    }
}
