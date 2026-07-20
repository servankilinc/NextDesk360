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
using ExpressDesk360.Model.Dtos.TicketStaff.Commands;
using ExpressDesk360.Model.Dtos.TicketStaff.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class TicketStaffService : ITicketStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public TicketStaffService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TicketStaff>> GetAsync(Expression<Func<TicketStaff, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStaffs.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketStaff>.NotFound();
            return Result<TicketStaff>.Success(result);
        }

        public async Task<Result<TicketStaff>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStaffs.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketStaff>.NotFound();
            return Result<TicketStaff>.Success(result);
        }

        public async Task<Result<TicketStaffDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStaffs.GetAsync<TicketStaffDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketStaffDto>.NotFound();
            return Result<TicketStaffDto>.Success(result);
        }

        public async Task<Result<ICollection<TicketStaff>>> GetListAsync(Expression<Func<TicketStaff, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStaffs.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketStaff>>.NotFound();
            return Result<ICollection<TicketStaff>>.Success(result);
        }

        public async Task<Result<ICollection<TicketStaff>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStaffs.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketStaff>>.NotFound();
            return Result<ICollection<TicketStaff>>.Success(result);
        }

        public async Task<Result<ICollection<TicketStaffDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStaffs.GetAllAsync<TicketStaffDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketStaffDto>>.NotFound();
            return Result<ICollection<TicketStaffDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(TicketStaffCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TicketStaffCreateDto");
            await _unitOfWork.TicketStaffs.AddAndSaveAsync(_mapper.Map<TicketStaff>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TicketStaffUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStaffs.GetAsync<TicketStaffUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketStaffUpdateDto>.NotFound();
            return Result<TicketStaffUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TicketStaffUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.TicketStaffs.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.TicketStaffs.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.TicketStaffs.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.TicketStaffs.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<TicketStaff>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStaffs.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TicketStaff>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TicketStaff>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStaffs.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TicketStaff>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TicketStaff>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketStaffs.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TicketStaff>>.Success(result);
        }
    }
}