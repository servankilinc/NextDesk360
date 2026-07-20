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
using ExpressDesk360.Model.Dtos.ProjectMovementType.Commands;
using ExpressDesk360.Model.Dtos.ProjectMovementType.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class ProjectMovementTypeService : IProjectMovementTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public ProjectMovementTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<ProjectMovementType>> GetAsync(Expression<Func<ProjectMovementType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovementTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectMovementType>.NotFound();
            return Result<ProjectMovementType>.Success(result);
        }

        public async Task<Result<ProjectMovementType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovementTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectMovementType>.NotFound();
            return Result<ProjectMovementType>.Success(result);
        }

        public async Task<Result<ProjectMovementTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovementTypes.GetAsync<ProjectMovementTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectMovementTypeDto>.NotFound();
            return Result<ProjectMovementTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<ProjectMovementType>>> GetListAsync(Expression<Func<ProjectMovementType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovementTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectMovementType>>.NotFound();
            return Result<ICollection<ProjectMovementType>>.Success(result);
        }

        public async Task<Result<ICollection<ProjectMovementType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovementTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectMovementType>>.NotFound();
            return Result<ICollection<ProjectMovementType>>.Success(result);
        }

        public async Task<Result<ICollection<ProjectMovementTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovementTypes.GetAllAsync<ProjectMovementTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectMovementTypeDto>>.NotFound();
            return Result<ICollection<ProjectMovementTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<ProjectMovementType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.ProjectMovementTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(ProjectMovementTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for ProjectMovementTypeCreateDto");
            await _unitOfWork.ProjectMovementTypes.AddAndSaveAsync(_mapper.Map<ProjectMovementType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<ProjectMovementTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovementTypes.GetAsync<ProjectMovementTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectMovementTypeUpdateDto>.NotFound();
            return Result<ProjectMovementTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(ProjectMovementTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.ProjectMovementTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.ProjectMovementTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.ProjectMovementTypes.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.ProjectMovementTypes.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<ProjectMovementType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovementTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<ProjectMovementType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<ProjectMovementType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovementTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<ProjectMovementType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<ProjectMovementType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectMovementTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<ProjectMovementType>>.Success(result);
        }
    }
}