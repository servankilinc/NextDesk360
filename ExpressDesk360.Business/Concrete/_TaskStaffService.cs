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
using ExpressDesk360.Model.Dtos._TaskStaff.Commands;
using ExpressDesk360.Model.Dtos._TaskStaff.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class _TaskStaffService : I_TaskStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public _TaskStaffService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<_TaskStaff>> GetAsync(Expression<Func<_TaskStaff, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStaffs.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<_TaskStaff>.NotFound();
            return Result<_TaskStaff>.Success(result);
        }

        public async Task<Result<_TaskStaff>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStaffs.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<_TaskStaff>.NotFound();
            return Result<_TaskStaff>.Success(result);
        }

        public async Task<Result<TaskStaffDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStaffs.GetAsync<TaskStaffDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskStaffDto>.NotFound();
            return Result<TaskStaffDto>.Success(result);
        }

        public async Task<Result<ICollection<_TaskStaff>>> GetListAsync(Expression<Func<_TaskStaff, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStaffs.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<_TaskStaff>>.NotFound();
            return Result<ICollection<_TaskStaff>>.Success(result);
        }

        public async Task<Result<ICollection<_TaskStaff>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStaffs.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<_TaskStaff>>.NotFound();
            return Result<ICollection<_TaskStaff>>.Success(result);
        }

        public async Task<Result<ICollection<TaskStaffDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStaffs.GetAllAsync<TaskStaffDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskStaffDto>>.NotFound();
            return Result<ICollection<TaskStaffDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(TaskStaffCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TaskStaffCreateDto");
            await _unitOfWork._TaskStaffs.AddAndSaveAsync(_mapper.Map<_TaskStaff>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TaskStaffUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStaffs.GetAsync<TaskStaffUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskStaffUpdateDto>.NotFound();
            return Result<TaskStaffUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TaskStaffUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork._TaskStaffs.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork._TaskStaffs.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork._TaskStaffs.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<_TaskStaff>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStaffs.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<_TaskStaff>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<_TaskStaff>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStaffs.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<_TaskStaff>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<_TaskStaff>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStaffs.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<_TaskStaff>>.Success(result);
        }
    }
}