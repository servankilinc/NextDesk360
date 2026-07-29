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
using ExpressDesk360.Model.Dtos._TaskStatus.Commands;
using ExpressDesk360.Model.Dtos._TaskStatus.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class _TaskStatusService : I_TaskStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public _TaskStatusService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<_TaskStatus>> GetAsync(Expression<Func<_TaskStatus, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStatuses.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<_TaskStatus>.NotFound();
            return Result<_TaskStatus>.Success(result);
        }

        public async Task<Result<_TaskStatus>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStatuses.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<_TaskStatus>.NotFound();
            return Result<_TaskStatus>.Success(result);
        }

        public async Task<Result<TaskStatusDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStatuses.GetAsync<TaskStatusDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskStatusDto>.NotFound();
            return Result<TaskStatusDto>.Success(result);
        }

        public async Task<Result<ICollection<_TaskStatus>>> GetListAsync(Expression<Func<_TaskStatus, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStatuses.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<_TaskStatus>>.NotFound();
            return Result<ICollection<_TaskStatus>>.Success(result);
        }

        public async Task<Result<ICollection<_TaskStatus>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStatuses.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<_TaskStatus>>.NotFound();
            return Result<ICollection<_TaskStatus>>.Success(result);
        }

        public async Task<Result<ICollection<TaskStatusDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStatuses.GetAllAsync<TaskStatusDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskStatusDto>>.NotFound();
            return Result<ICollection<TaskStatusDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<_TaskStatus, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork._TaskStatuses.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TaskStatusCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TaskStatusCreateDto");
            await _unitOfWork._TaskStatuses.AddAndSaveAsync(_mapper.Map<_TaskStatus>(request), cancellationToken);
            return Result.Success();
        }





        public async Task<Result<PaginationResponse<_TaskStatus>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStatuses.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<_TaskStatus>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<_TaskStatus>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStatuses.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<_TaskStatus>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<_TaskStatus>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskStatuses.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<_TaskStatus>>.Success(result);
        }
    }
}
