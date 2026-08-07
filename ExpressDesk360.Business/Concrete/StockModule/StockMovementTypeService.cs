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
using ExpressDesk360.Model.Dtos.StockModule.StockMovementType.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockMovementType.Queries;
using ExpressDesk360.Business.Abstract.StockModule;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Concrete.StockModule
{
    public class StockMovementTypeService : IStockMovementTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockMovementTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockMovementType>> GetAsync(Expression<Func<StockMovementType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovementType>.NotFound();
            return Result<StockMovementType>.Success(result);
        }

        public async Task<Result<StockMovementType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovementType>.NotFound();
            return Result<StockMovementType>.Success(result);
        }

        public async Task<Result<StockMovementTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementTypes.GetAsync<StockMovementTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovementTypeDto>.NotFound();
            return Result<StockMovementTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<StockMovementType>>> GetListAsync(Expression<Func<StockMovementType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockMovementType>>.NotFound();
            return Result<ICollection<StockMovementType>>.Success(result);
        }

        public async Task<Result<ICollection<StockMovementType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockMovementType>>.NotFound();
            return Result<ICollection<StockMovementType>>.Success(result);
        }

        public async Task<Result<ICollection<StockMovementTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementTypes.GetAllAsync<StockMovementTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockMovementTypeDto>>.NotFound();
            return Result<ICollection<StockMovementTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<StockMovementType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.StockMovementTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(StockMovementTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockMovementTypeCreateDto");
            await _unitOfWork.StockMovementTypes.AddAndSaveAsync(_mapper.Map<StockMovementType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockMovementTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementTypes.GetAsync<StockMovementTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovementTypeUpdateDto>.NotFound();
            return Result<StockMovementTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockMovementTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.StockMovementTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.StockMovementTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<StockMovementType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockMovementType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockMovementType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockMovementType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockMovementType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovementTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockMovementType>>.Success(result);
        }
    }
}
