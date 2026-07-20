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
using ExpressDesk360.Model.Dtos.ProjectStatus.Commands;
using ExpressDesk360.Model.Dtos.ProjectStatus.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class ProjectStatusService : IProjectStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public ProjectStatusService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<ProjectStatus>> GetAsync(Expression<Func<ProjectStatus, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStatuses.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectStatus>.NotFound();
            return Result<ProjectStatus>.Success(result);
        }

        public async Task<Result<ProjectStatus>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStatuses.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectStatus>.NotFound();
            return Result<ProjectStatus>.Success(result);
        }

        public async Task<Result<ProjectStatusDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStatuses.GetAsync<ProjectStatusDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectStatusDto>.NotFound();
            return Result<ProjectStatusDto>.Success(result);
        }

        public async Task<Result<ICollection<ProjectStatus>>> GetListAsync(Expression<Func<ProjectStatus, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStatuses.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectStatus>>.NotFound();
            return Result<ICollection<ProjectStatus>>.Success(result);
        }

        public async Task<Result<ICollection<ProjectStatus>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStatuses.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectStatus>>.NotFound();
            return Result<ICollection<ProjectStatus>>.Success(result);
        }

        public async Task<Result<ICollection<ProjectStatusDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStatuses.GetAllAsync<ProjectStatusDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectStatusDto>>.NotFound();
            return Result<ICollection<ProjectStatusDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<ProjectStatus, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.ProjectStatuses.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(ProjectStatusCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for ProjectStatusCreateDto");
            await _unitOfWork.ProjectStatuses.AddAndSaveAsync(_mapper.Map<ProjectStatus>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<ProjectStatusUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStatuses.GetAsync<ProjectStatusUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectStatusUpdateDto>.NotFound();
            return Result<ProjectStatusUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(ProjectStatusUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.ProjectStatuses.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.ProjectStatuses.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.ProjectStatuses.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.ProjectStatuses.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<ProjectStatus>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStatuses.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<ProjectStatus>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<ProjectStatus>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStatuses.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<ProjectStatus>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<ProjectStatus>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStatuses.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<ProjectStatus>>.Success(result);
        }
    }
}