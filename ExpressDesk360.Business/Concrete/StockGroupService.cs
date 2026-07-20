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
using ExpressDesk360.Model.Dtos.StockGroup.Commands;
using ExpressDesk360.Model.Dtos.StockGroup.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class StockGroupService : IStockGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockGroupService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockGroup>> GetAsync(Expression<Func<StockGroup, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroup>.NotFound();
            return Result<StockGroup>.Success(result);
        }

        public async Task<Result<StockGroup>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroup>.NotFound();
            return Result<StockGroup>.Success(result);
        }

        public async Task<Result<StockGroupDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAsync<StockGroupDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupDto>.NotFound();
            return Result<StockGroupDto>.Success(result);
        }

        public async Task<Result<ICollection<StockGroup>>> GetListAsync(Expression<Func<StockGroup, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroup>>.NotFound();
            return Result<ICollection<StockGroup>>.Success(result);
        }

        public async Task<Result<ICollection<StockGroup>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroup>>.NotFound();
            return Result<ICollection<StockGroup>>.Success(result);
        }

        public async Task<Result<ICollection<StockGroupDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAllAsync<StockGroupDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroupDto>>.NotFound();
            return Result<ICollection<StockGroupDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<StockGroup, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.StockGroups.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(StockGroupCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockGroupCreateDto");
            await _unitOfWork.StockGroups.AddAndSaveAsync(_mapper.Map<StockGroup>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockGroupUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAsync<StockGroupUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupUpdateDto>.NotFound();
            return Result<StockGroupUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockGroupUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.StockGroups.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.StockGroups.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.StockGroups.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.StockGroups.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<StockGroup>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockGroup>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockGroup>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockGroup>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockGroup>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockGroup>>.Success(result);
        }
    }
}