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
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.Business.Abstract.TaskModule;
using ExpressDesk360.Model.Dtos.TaskModule.TaskFile.Queries;
using ExpressDesk360.Model.Dtos.TaskModule.TaskFile.Commands;

namespace ExpressDesk360.Business.Concrete
{
    public class _TaskFileService : ITaskFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public _TaskFileService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TaskFile>> GetAsync(Expression<Func<TaskFile, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskFiles.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskFile>.NotFound();
            return Result<TaskFile>.Success(result);
        }

        public async Task<Result<TaskFile>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskFiles.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskFile>.NotFound();
            return Result<TaskFile>.Success(result);
        }

        public async Task<Result<TaskFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskFiles.GetAsync<TaskFileDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskFileDto>.NotFound();
            return Result<TaskFileDto>.Success(result);
        }

        public async Task<Result<ICollection<TaskFile>>> GetListAsync(Expression<Func<TaskFile, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskFiles.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskFile>>.NotFound();
            return Result<ICollection<TaskFile>>.Success(result);
        }

        public async Task<Result<ICollection<TaskFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskFiles.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskFile>>.NotFound();
            return Result<ICollection<TaskFile>>.Success(result);
        }

        public async Task<Result<ICollection<TaskFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskFiles.GetAllAsync<TaskFileDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskFileDto>>.NotFound();
            return Result<ICollection<TaskFileDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(TaskFileCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TaskFileCreateDto");
            await _unitOfWork._TaskFiles.AddAndSaveAsync(_mapper.Map<TaskFile>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TaskFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskFiles.GetAsync<TaskFileUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskFileUpdateDto>.NotFound();
            return Result<TaskFileUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TaskFileUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork._TaskFiles.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork._TaskFiles.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork._TaskFiles.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<TaskFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskFiles.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TaskFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TaskFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskFiles.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TaskFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TaskFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskFiles.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TaskFile>>.Success(result);
        }
    }
}