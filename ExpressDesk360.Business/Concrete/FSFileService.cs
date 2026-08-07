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
using ExpressDesk360.Model.Dtos.Common.FSFile.Commands;
using ExpressDesk360.Model.Dtos.Common.FSFile.Queries;
using ExpressDesk360.Model.Entities.Common;
using ExpressDesk360.Business.Abstract.Common;

namespace ExpressDesk360.Business.Concrete
{
    public class FSFileService : IFSFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public FSFileService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<FSFile>> GetAsync(Expression<Func<FSFile, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFiles.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FSFile>.NotFound();
            return Result<FSFile>.Success(result);
        }

        public async Task<Result<FSFile>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFiles.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FSFile>.NotFound();
            return Result<FSFile>.Success(result);
        }

        public async Task<Result<FSFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFiles.GetAsync<FSFileDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FSFileDto>.NotFound();
            return Result<FSFileDto>.Success(result);
        }

        public async Task<Result<ICollection<FSFile>>> GetListAsync(Expression<Func<FSFile, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFiles.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<FSFile>>.NotFound();
            return Result<ICollection<FSFile>>.Success(result);
        }

        public async Task<Result<ICollection<FSFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFiles.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<FSFile>>.NotFound();
            return Result<ICollection<FSFile>>.Success(result);
        }

        public async Task<Result<ICollection<FSFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFiles.GetAllAsync<FSFileDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<FSFileDto>>.NotFound();
            return Result<ICollection<FSFileDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<FSFile, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.FSFiles.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(FSFileCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for FSFileCreateDto");
            await _unitOfWork.FSFiles.AddAndSaveAsync(_mapper.Map<FSFile>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<FSFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFiles.GetAsync<FSFileUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FSFileUpdateDto>.NotFound();
            return Result<FSFileUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(FSFileUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.FSFiles.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.FSFiles.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.FSFiles.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<FSFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFiles.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<FSFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<FSFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFiles.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<FSFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<FSFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FSFiles.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<FSFile>>.Success(result);
        }
    }
}