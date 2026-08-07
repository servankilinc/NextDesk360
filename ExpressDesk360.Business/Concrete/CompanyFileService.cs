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
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyFile.Commands;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyFile.Queries;
using ExpressDesk360.Model.Entities.CompanyModule;
using ExpressDesk360.Business.Abstract.CompanyModule;

namespace ExpressDesk360.Business.Concrete
{
    public class CompanyFileService : ICompanyFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public CompanyFileService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<CompanyFile>> GetAsync(Expression<Func<CompanyFile, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyFiles.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyFile>.NotFound();
            return Result<CompanyFile>.Success(result);
        }

        public async Task<Result<CompanyFile>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyFiles.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyFile>.NotFound();
            return Result<CompanyFile>.Success(result);
        }

        public async Task<Result<CompanyFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyFiles.GetAsync<CompanyFileDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyFileDto>.NotFound();
            return Result<CompanyFileDto>.Success(result);
        }

        public async Task<Result<ICollection<CompanyFile>>> GetListAsync(Expression<Func<CompanyFile, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyFiles.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyFile>>.NotFound();
            return Result<ICollection<CompanyFile>>.Success(result);
        }

        public async Task<Result<ICollection<CompanyFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyFiles.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyFile>>.NotFound();
            return Result<ICollection<CompanyFile>>.Success(result);
        }

        public async Task<Result<ICollection<CompanyFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyFiles.GetAllAsync<CompanyFileDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyFileDto>>.NotFound();
            return Result<ICollection<CompanyFileDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(CompanyFileCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for CompanyFileCreateDto");
            await _unitOfWork.CompanyFiles.AddAndSaveAsync(_mapper.Map<CompanyFile>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<CompanyFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyFiles.GetAsync<CompanyFileUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyFileUpdateDto>.NotFound();
            return Result<CompanyFileUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(CompanyFileUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.CompanyFiles.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.CompanyFiles.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.CompanyFiles.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<CompanyFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyFiles.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<CompanyFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<CompanyFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyFiles.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<CompanyFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<CompanyFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyFiles.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<CompanyFile>>.Success(result);
        }
    }
}