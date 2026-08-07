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
using ExpressDesk360.Model.Dtos.StockModule.StockType.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockType.Queries;
using ExpressDesk360.Business.Abstract.StockModule;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Concrete.StockModule
{
    public class StockTypeService : IStockTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockType>> GetAsync(Expression<Func<StockType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockType>.NotFound();
            return Result<StockType>.Success(result);
        }

        public async Task<Result<StockType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockType>.NotFound();
            return Result<StockType>.Success(result);
        }

        public async Task<Result<StockTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypes.GetAsync<StockTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockTypeDto>.NotFound();
            return Result<StockTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<StockType>>> GetListAsync(Expression<Func<StockType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockType>>.NotFound();
            return Result<ICollection<StockType>>.Success(result);
        }

        public async Task<Result<ICollection<StockType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockType>>.NotFound();
            return Result<ICollection<StockType>>.Success(result);
        }

        public async Task<Result<ICollection<StockTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypes.GetAllAsync<StockTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockTypeDto>>.NotFound();
            return Result<ICollection<StockTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<StockType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.StockTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(StockTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockTypeCreateDto");
            await _unitOfWork.StockTypes.AddAndSaveAsync(_mapper.Map<StockType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypes.GetAsync<StockTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockTypeUpdateDto>.NotFound();
            return Result<StockTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.StockTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.StockTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<StockType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockType>>.Success(result);
        }
    }
}
