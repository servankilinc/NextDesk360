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
using ExpressDesk360.Model.Dtos.FSFolder.Commands;
using ExpressDesk360.Model.Dtos.FSFolder.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class FSFolderService : IFSFolderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public FSFolderService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<FSFolder>> GetAsync(Expression<Func<FSFolder, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFolders.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FSFolder>.NotFound();
            return Result<FSFolder>.Success(result);
        }

        public async Task<Result<FSFolder>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFolders.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FSFolder>.NotFound();
            return Result<FSFolder>.Success(result);
        }

        public async Task<Result<FSFolderDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFolders.GetAsync<FSFolderDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FSFolderDto>.NotFound();
            return Result<FSFolderDto>.Success(result);
        }

        public async Task<Result<ICollection<FSFolder>>> GetListAsync(Expression<Func<FSFolder, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFolders.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<FSFolder>>.NotFound();
            return Result<ICollection<FSFolder>>.Success(result);
        }

        public async Task<Result<ICollection<FSFolder>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFolders.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<FSFolder>>.NotFound();
            return Result<ICollection<FSFolder>>.Success(result);
        }

        public async Task<Result<ICollection<FSFolderDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFolders.GetAllAsync<FSFolderDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<FSFolderDto>>.NotFound();
            return Result<ICollection<FSFolderDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<FSFolder, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.FSFolders.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(FSFolderCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for FSFolderCreateDto");
            await _unitOfWork.FSFolders.AddAndSaveAsync(_mapper.Map<FSFolder>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<FSFolderUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFolders.GetAsync<FSFolderUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FSFolderUpdateDto>.NotFound();
            return Result<FSFolderUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(FSFolderUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.FSFolders.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.FSFolders.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.FSFolders.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.FSFolders.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<FSFolder>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFolders.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<FSFolder>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<FSFolder>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFolders.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<FSFolder>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<FSFolder>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFolders.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<FSFolder>>.Success(result);
        }
    }
}