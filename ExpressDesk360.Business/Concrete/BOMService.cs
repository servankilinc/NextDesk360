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
using ExpressDesk360.Model.Dtos.BOM.Commands;
using ExpressDesk360.Model.Dtos.BOM.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class BOMService : IBOMService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public BOMService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<BOM>> GetAsync(Expression<Func<BOM, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMs.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<BOM>.NotFound();
            return Result<BOM>.Success(result);
        }

        public async Task<Result<BOM>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMs.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<BOM>.NotFound();
            return Result<BOM>.Success(result);
        }

        public async Task<Result<BOMDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMs.GetAsync<BOMDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<BOMDto>.NotFound();
            return Result<BOMDto>.Success(result);
        }

        public async Task<Result<ICollection<BOM>>> GetListAsync(Expression<Func<BOM, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMs.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<BOM>>.NotFound();
            return Result<ICollection<BOM>>.Success(result);
        }

        public async Task<Result<ICollection<BOM>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMs.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<BOM>>.NotFound();
            return Result<ICollection<BOM>>.Success(result);
        }

        public async Task<Result<ICollection<BOMDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMs.GetAllAsync<BOMDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<BOMDto>>.NotFound();
            return Result<ICollection<BOMDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<BOM, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.BOMs.GetAllAsync<object>(select: s => new { s.Id, s.VersionName }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "VersionName");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(BOMCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for BOMCreateDto");
            await _unitOfWork.BOMs.AddAndSaveAsync(_mapper.Map<BOM>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<BOMUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMs.GetAsync<BOMUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<BOMUpdateDto>.NotFound();
            return Result<BOMUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(BOMUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.BOMs.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.BOMs.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.BOMs.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.BOMs.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<BOM>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMs.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<BOM>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<BOM>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMs.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<BOM>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<BOM>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.BOMs.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<BOM>>.Success(result);
        }
    }
}