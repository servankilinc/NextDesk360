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
using ExpressDesk360.Model.Dtos.Warehouse.Commands;
using ExpressDesk360.Model.Dtos.Warehouse.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public WarehouseService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<Warehouse>> GetAsync(Expression<Func<Warehouse, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Warehouses.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Warehouse>.NotFound();
            return Result<Warehouse>.Success(result);
        }

        public async Task<Result<Warehouse>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Warehouses.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Warehouse>.NotFound();
            return Result<Warehouse>.Success(result);
        }

        public async Task<Result<WarehouseDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Warehouses.GetAsync<WarehouseDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<WarehouseDto>.NotFound();
            return Result<WarehouseDto>.Success(result);
        }

        public async Task<Result<ICollection<Warehouse>>> GetListAsync(Expression<Func<Warehouse, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Warehouses.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Warehouse>>.NotFound();
            return Result<ICollection<Warehouse>>.Success(result);
        }

        public async Task<Result<ICollection<Warehouse>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Warehouses.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Warehouse>>.NotFound();
            return Result<ICollection<Warehouse>>.Success(result);
        }

        public async Task<Result<ICollection<WarehouseDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Warehouses.GetAllAsync<WarehouseDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<WarehouseDto>>.NotFound();
            return Result<ICollection<WarehouseDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<Warehouse, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.Warehouses.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(WarehouseCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for WarehouseCreateDto");
            await _unitOfWork.Warehouses.AddAndSaveAsync(_mapper.Map<Warehouse>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<WarehouseUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Warehouses.GetAsync<WarehouseUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<WarehouseUpdateDto>.NotFound();
            return Result<WarehouseUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(WarehouseUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.Warehouses.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.Warehouses.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<Warehouse>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Warehouses.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<Warehouse>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<Warehouse>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Warehouses.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<Warehouse>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<Warehouse>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Warehouses.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<Warehouse>>.Success(result);
        }
    }
}
