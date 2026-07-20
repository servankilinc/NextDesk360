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
using ExpressDesk360.Model.Dtos.ProjectMovement.Commands;
using ExpressDesk360.Model.Dtos.ProjectMovement.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class ProjectMovementService : IProjectMovementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public ProjectMovementService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<ProjectMovement>> GetAsync(Expression<Func<ProjectMovement, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovements.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectMovement>.NotFound();
            return Result<ProjectMovement>.Success(result);
        }

        public async Task<Result<ProjectMovement>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovements.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectMovement>.NotFound();
            return Result<ProjectMovement>.Success(result);
        }

        public async Task<Result<ProjectMovementDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovements.GetAsync<ProjectMovementDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectMovementDto>.NotFound();
            return Result<ProjectMovementDto>.Success(result);
        }

        public async Task<Result<ICollection<ProjectMovement>>> GetListAsync(Expression<Func<ProjectMovement, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovements.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectMovement>>.NotFound();
            return Result<ICollection<ProjectMovement>>.Success(result);
        }

        public async Task<Result<ICollection<ProjectMovement>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovements.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectMovement>>.NotFound();
            return Result<ICollection<ProjectMovement>>.Success(result);
        }

        public async Task<Result<ICollection<ProjectMovementDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovements.GetAllAsync<ProjectMovementDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectMovementDto>>.NotFound();
            return Result<ICollection<ProjectMovementDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<ProjectMovement, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.ProjectMovements.GetAllAsync<object>(select: s => new { s.Id, s.Description }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Description");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(ProjectMovementCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for ProjectMovementCreateDto");
            await _unitOfWork.ProjectMovements.AddAndSaveAsync(_mapper.Map<ProjectMovement>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<ProjectMovementUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovements.GetAsync<ProjectMovementUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectMovementUpdateDto>.NotFound();
            return Result<ProjectMovementUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(ProjectMovementUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.ProjectMovements.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.ProjectMovements.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.ProjectMovements.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.ProjectMovements.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<ProjectMovement>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovements.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<ProjectMovement>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<ProjectMovement>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovements.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<ProjectMovement>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<ProjectMovement>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovements.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<ProjectMovement>>.Success(result);
        }
    }
}