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
using ExpressDesk360.Model.Dtos._TaskPriority.Commands;
using ExpressDesk360.Model.Dtos._TaskPriority.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class _TaskPriorityService : I_TaskPriorityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public _TaskPriorityService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<_TaskPriority>> GetAsync(Expression<Func<_TaskPriority, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskPriorities.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<_TaskPriority>.NotFound();
            return Result<_TaskPriority>.Success(result);
        }

        public async Task<Result<_TaskPriority>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskPriorities.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<_TaskPriority>.NotFound();
            return Result<_TaskPriority>.Success(result);
        }

        public async Task<Result<TaskPriorityDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskPriorities.GetAsync<TaskPriorityDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskPriorityDto>.NotFound();
            return Result<TaskPriorityDto>.Success(result);
        }

        public async Task<Result<ICollection<_TaskPriority>>> GetListAsync(Expression<Func<_TaskPriority, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskPriorities.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<_TaskPriority>>.NotFound();
            return Result<ICollection<_TaskPriority>>.Success(result);
        }

        public async Task<Result<ICollection<_TaskPriority>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskPriorities.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<_TaskPriority>>.NotFound();
            return Result<ICollection<_TaskPriority>>.Success(result);
        }

        public async Task<Result<ICollection<TaskPriorityDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskPriorities.GetAllAsync<TaskPriorityDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskPriorityDto>>.NotFound();
            return Result<ICollection<TaskPriorityDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<_TaskPriority, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork._TaskPriorities.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TaskPriorityCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TaskPriorityCreateDto");
            await _unitOfWork._TaskPriorities.AddAndSaveAsync(_mapper.Map<_TaskPriority>(request), cancellationToken);
            return Result.Success();
        }





        public async Task<Result<PaginationResponse<_TaskPriority>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskPriorities.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<_TaskPriority>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<_TaskPriority>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskPriorities.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<_TaskPriority>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<_TaskPriority>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskPriorities.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<_TaskPriority>>.Success(result);
        }
    }
}
