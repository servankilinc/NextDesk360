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
using ExpressDesk360.Model.Dtos.UserFile.Commands;
using ExpressDesk360.Model.Dtos.UserFile.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class UserFileService : IUserFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public UserFileService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<UserFile>> GetAsync(Expression<Func<UserFile, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserFiles.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UserFile>.NotFound();
            return Result<UserFile>.Success(result);
        }

        public async Task<Result<UserFile>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserFiles.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UserFile>.NotFound();
            return Result<UserFile>.Success(result);
        }

        public async Task<Result<UserFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserFiles.GetAsync<UserFileDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UserFileDto>.NotFound();
            return Result<UserFileDto>.Success(result);
        }

        public async Task<Result<ICollection<UserFile>>> GetListAsync(Expression<Func<UserFile, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserFiles.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<UserFile>>.NotFound();
            return Result<ICollection<UserFile>>.Success(result);
        }

        public async Task<Result<ICollection<UserFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserFiles.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<UserFile>>.NotFound();
            return Result<ICollection<UserFile>>.Success(result);
        }

        public async Task<Result<ICollection<UserFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserFiles.GetAllAsync<UserFileDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<UserFileDto>>.NotFound();
            return Result<ICollection<UserFileDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(UserFileCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for UserFileCreateDto");
            await _unitOfWork.UserFiles.AddAndSaveAsync(_mapper.Map<UserFile>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<UserFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserFiles.GetAsync<UserFileUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UserFileUpdateDto>.NotFound();
            return Result<UserFileUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(UserFileUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.UserFiles.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.UserFiles.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.UserFiles.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.UserFiles.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<UserFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserFiles.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<UserFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<UserFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserFiles.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<UserFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<UserFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserFiles.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<UserFile>>.Success(result);
        }
    }
}