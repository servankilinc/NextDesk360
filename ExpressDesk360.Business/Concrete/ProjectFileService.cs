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
using ExpressDesk360.Model.Dtos.ProjectFile.Commands;
using ExpressDesk360.Model.Dtos.ProjectFile.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class ProjectFileService : IProjectFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public ProjectFileService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<ProjectFile>> GetAsync(Expression<Func<ProjectFile, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectFiles.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectFile>.NotFound();
            return Result<ProjectFile>.Success(result);
        }

        public async Task<Result<ProjectFile>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectFiles.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectFile>.NotFound();
            return Result<ProjectFile>.Success(result);
        }

        public async Task<Result<ProjectFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectFiles.GetAsync<ProjectFileDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectFileDto>.NotFound();
            return Result<ProjectFileDto>.Success(result);
        }

        public async Task<Result<ICollection<ProjectFile>>> GetListAsync(Expression<Func<ProjectFile, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectFiles.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectFile>>.NotFound();
            return Result<ICollection<ProjectFile>>.Success(result);
        }

        public async Task<Result<ICollection<ProjectFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectFiles.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectFile>>.NotFound();
            return Result<ICollection<ProjectFile>>.Success(result);
        }

        public async Task<Result<ICollection<ProjectFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectFiles.GetAllAsync<ProjectFileDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectFileDto>>.NotFound();
            return Result<ICollection<ProjectFileDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(ProjectFileCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for ProjectFileCreateDto");
            await _unitOfWork.ProjectFiles.AddAndSaveAsync(_mapper.Map<ProjectFile>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<ProjectFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectFiles.GetAsync<ProjectFileUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectFileUpdateDto>.NotFound();
            return Result<ProjectFileUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(ProjectFileUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.ProjectFiles.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.ProjectFiles.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.ProjectFiles.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.ProjectFiles.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<ProjectFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectFiles.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<ProjectFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<ProjectFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectFiles.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<ProjectFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<ProjectFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectFiles.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<ProjectFile>>.Success(result);
        }
    }
}