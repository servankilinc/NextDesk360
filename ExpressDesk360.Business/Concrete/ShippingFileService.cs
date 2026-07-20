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
using ExpressDesk360.Model.Dtos.ShippingFile.Commands;
using ExpressDesk360.Model.Dtos.ShippingFile.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class ShippingFileService : IShippingFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public ShippingFileService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<ShippingFile>> GetAsync(Expression<Func<ShippingFile, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingFiles.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ShippingFile>.NotFound();
            return Result<ShippingFile>.Success(result);
        }

        public async Task<Result<ShippingFile>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingFiles.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ShippingFile>.NotFound();
            return Result<ShippingFile>.Success(result);
        }

        public async Task<Result<ShippingFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingFiles.GetAsync<ShippingFileDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ShippingFileDto>.NotFound();
            return Result<ShippingFileDto>.Success(result);
        }

        public async Task<Result<ICollection<ShippingFile>>> GetListAsync(Expression<Func<ShippingFile, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingFiles.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ShippingFile>>.NotFound();
            return Result<ICollection<ShippingFile>>.Success(result);
        }

        public async Task<Result<ICollection<ShippingFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingFiles.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ShippingFile>>.NotFound();
            return Result<ICollection<ShippingFile>>.Success(result);
        }

        public async Task<Result<ICollection<ShippingFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingFiles.GetAllAsync<ShippingFileDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ShippingFileDto>>.NotFound();
            return Result<ICollection<ShippingFileDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(ShippingFileCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for ShippingFileCreateDto");
            await _unitOfWork.ShippingFiles.AddAndSaveAsync(_mapper.Map<ShippingFile>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<ShippingFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingFiles.GetAsync<ShippingFileUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ShippingFileUpdateDto>.NotFound();
            return Result<ShippingFileUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(ShippingFileUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.ShippingFiles.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.ShippingFiles.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.ShippingFiles.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.ShippingFiles.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<ShippingFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingFiles.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<ShippingFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<ShippingFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingFiles.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<ShippingFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<ShippingFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ShippingFiles.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<ShippingFile>>.Success(result);
        }
    }
}