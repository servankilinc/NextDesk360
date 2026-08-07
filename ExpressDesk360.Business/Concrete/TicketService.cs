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
using ExpressDesk360.Model.Enums;
using ExpressDesk360.Model.Dtos.TicketModule.Ticket.Commands;
using ExpressDesk360.Model.Dtos.TicketModule.Ticket.Queries;
using ExpressDesk360.Model.Entities.TicketModule;
using ExpressDesk360.Business.Abstract.TicketModule;

namespace ExpressDesk360.Business.Concrete
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public TicketService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<Ticket>> GetAsync(Expression<Func<Ticket, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Tickets.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Ticket>.NotFound();
            return Result<Ticket>.Success(result);
        }

        public async Task<Result<Ticket>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Tickets.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Ticket>.NotFound();
            return Result<Ticket>.Success(result);
        }

        public async Task<Result<TicketDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Tickets.GetAsync<TicketDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketDto>.NotFound();
            return Result<TicketDto>.Success(result);
        }

        public async Task<Result<ICollection<Ticket>>> GetListAsync(Expression<Func<Ticket, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Tickets.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Ticket>>.NotFound();
            return Result<ICollection<Ticket>>.Success(result);
        }

        public async Task<Result<ICollection<Ticket>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Tickets.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Ticket>>.NotFound();
            return Result<ICollection<Ticket>>.Success(result);
        }

        public async Task<Result<ICollection<TicketDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Tickets.GetAllAsync<TicketDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketDto>>.NotFound();
            return Result<ICollection<TicketDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<Ticket, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.Tickets.GetAllAsync<object>(select: s => new { s.Id, s.Title }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Title");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TicketCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TicketCreateDto");

            var ticket = _mapper.Map<Ticket>(request);

            var numberList = await _unitOfWork.Tickets.GetAllAsync<int>(select: t => t.Number, cancellationToken: cancellationToken);
            int nextNumber = 1;
            if (numberList != null && numberList.Any())
                nextNumber = numberList.Max() + 1;

            ticket.Number = nextNumber;
            ticket.Date = DateTime.Now;
            ticket.DueDate = null;
            ticket.LastTicketMovementTypeId = (int)TicketEnums.TicketMovementType.NewTicket;

            bool underWarranty = false;
            if (ticket.CompanyProductId.HasValue && ticket.CompanyProductId.Value != Guid.Empty)
            {
                var warranty = await _unitOfWork.CompanyProductWarranties.GetAsync(
                    where: w => w.CompanyProductId == ticket.CompanyProductId.Value && 
                                w.Status == true && 
                                w.StartDate <= DateTime.Now && 
                                w.EndDate >= DateTime.Now && 
                                !w.IsDeleted,
                    cancellationToken: cancellationToken
                );
                if (warranty != null)
                    underWarranty = true;
            }
            ticket.UnderWarranty = underWarranty;

            await _unitOfWork.Tickets.AddAndSaveAsync(ticket, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TicketUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Tickets.GetAsync<TicketUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketUpdateDto>.NotFound();
            return Result<TicketUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TicketUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.Tickets.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.Tickets.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.Tickets.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.Tickets.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<Ticket>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Tickets.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<Ticket>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<Ticket>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Tickets.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<Ticket>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TicketReportDto>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Tickets.DatatableServerSideAsync<TicketReportDto>(datatableRequest: request, configurationProvider: _mapper.ConfigurationProvider, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TicketReportDto>>.Success(result);
        }
    }
}