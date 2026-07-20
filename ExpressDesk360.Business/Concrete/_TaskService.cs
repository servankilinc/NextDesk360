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
using ExpressDesk360.Model.Dtos._Task.Commands;
using ExpressDesk360.Model.Dtos._Task.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class _TaskService : I_TaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public _TaskService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<_Task>> GetAsync(Expression<Func<_Task, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._Tasks.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<_Task>.NotFound();
            return Result<_Task>.Success(result);
        }

        public async Task<Result<_Task>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._Tasks.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<_Task>.NotFound();
            return Result<_Task>.Success(result);
        }

        public async Task<Result<TaskDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._Tasks.GetAsync<TaskDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskDto>.NotFound();
            return Result<TaskDto>.Success(result);
        }

        public async Task<Result<ICollection<_Task>>> GetListAsync(Expression<Func<_Task, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._Tasks.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<_Task>>.NotFound();
            return Result<ICollection<_Task>>.Success(result);
        }

        public async Task<Result<ICollection<_Task>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._Tasks.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<_Task>>.NotFound();
            return Result<ICollection<_Task>>.Success(result);
        }

        public async Task<Result<ICollection<TaskDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._Tasks.GetAllAsync<TaskDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskDto>>.NotFound();
            return Result<ICollection<TaskDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<_Task, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork._Tasks.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TaskCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TaskCreateDto");
            await _unitOfWork._Tasks.AddAndSaveAsync(_mapper.Map<_Task>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TaskUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._Tasks.GetAsync<TaskUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskUpdateDto>.NotFound();
            return Result<TaskUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TaskUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork._Tasks.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork._Tasks.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork._Tasks.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork._Tasks.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<_Task>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._Tasks.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<_Task>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<_Task>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._Tasks.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<_Task>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<_Task>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._Tasks.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<_Task>>.Success(result);
        }
    }
}