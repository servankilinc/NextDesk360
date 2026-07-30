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
using ExpressDesk360.Model.Dtos.Stock.Commands;
using ExpressDesk360.Model.Dtos.Stock.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<Stock>> GetAsync(Expression<Func<Stock, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Stock>.NotFound();
            return Result<Stock>.Success(result);
        }

        public async Task<Result<Stock>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Stock>.NotFound();
            return Result<Stock>.Success(result);
        }

        public async Task<Result<Stock>> GetDetailAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.GetAsync(
                where: f => f.Id == id,
                include: i => i.Include(x => x.StockGroup)
                               .Include(x => x.StockBrand)
                               .Include(x => x.Unit)
                               .Include(x => x.PurchaseCurrency)
                               .Include(x => x.SalePriceCurrency),
                cancellationToken: cancellationToken);

            if (result == null)
                return Result<Stock>.NotFound();
            return Result<Stock>.Success(result);
        }

        public async Task<Result<StockDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.GetAsync<StockDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockDto>.NotFound();
            return Result<StockDto>.Success(result);
        }

        public async Task<Result<ICollection<Stock>>> GetListAsync(Expression<Func<Stock, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Stock>>.NotFound();
            return Result<ICollection<Stock>>.Success(result);
        }

        public async Task<Result<ICollection<Stock>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Stock>>.NotFound();
            return Result<ICollection<Stock>>.Success(result);
        }

        public async Task<Result<ICollection<StockDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.GetAllAsync<StockDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockDto>>.NotFound();
            return Result<ICollection<StockDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<Stock, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.Stocks.GetAllAsync<object>(select: s => new { s.Id, s.ModelName }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "ModelName");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(StockCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockCreateDto");
            await _unitOfWork.Stocks.AddAndSaveAsync(_mapper.Map<Stock>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.GetAsync<StockUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockUpdateDto>.NotFound();
            return Result<StockUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.Stocks.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.Stocks.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<Stock>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<Stock>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<Stock>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<Stock>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockReportDto>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Stocks.DatatableServerSideAsync(
                datatableRequest: request,
                select: s => new StockReportDto
                {
                    Id = s.Id,
                    ModelName = s.ModelName,
                    ModelCode = s.ModelCode,
                    ModelType = s.ModelType,
                    UnitShortName = s.Unit != null ? s.Unit.ShortName : null,
                    SerialTracking = s.SerialTracking,
                    Vat = s.Vat,
                    PurchasePrice = s.PurchasePrice,
                    PurchaseCurrencyShortName = s.PurchaseCurrency != null ? s.PurchaseCurrency.ShortName : null,
                    SalePrice = s.SalePrice,
                    SalePriceCurrencyShortName = s.SalePriceCurrency != null ? s.SalePriceCurrency.ShortName : null,
                    StockGroupName = s.StockGroup != null ? s.StockGroup.Name : null,
                    StockBrandName = s.StockBrand != null ? s.StockBrand.Name : null,
                    TotalSerialCount = s.StockSerials.Count(),
                    AvailableSerialCount = s.StockSerials.Count(x => !x.CompanyProductStockSerialMaps.Any()),
                    IsActive = s.IsActive,
                    CreateDateUtc = s.CreateDateUtc,
                    UpdateDateUtc = s.UpdateDateUtc
                },
                cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockReportDto>>.Success(result);
        }

        public async Task<Result<object>> GetDashboardDataAsync(CancellationToken cancellationToken = default)
        {
            var totalStockModels = await _unitOfWork.Stocks.CountAsync(cancellationToken: cancellationToken);
            var totalActiveSerials = await _unitOfWork.StockSerials.CountAsync(
                where: s => s.StockSerialWarranties.Any(w => w.EndDate >= DateTime.UtcNow), 
                cancellationToken: cancellationToken);
            var totalSerials = await _unitOfWork.StockSerials.CountAsync(cancellationToken: cancellationToken);
            var attachedSerials = await _unitOfWork.StockSerials.CountAsync(
                where: s => s.CompanyProductStockSerialMaps.Any(), 
                cancellationToken: cancellationToken);
            var recentMovements = await _unitOfWork.StockMovements.GetAllAsync<object>(
                select: s => new { 
                    s.Date, 
                    StockModelName = s.Stock != null ? s.Stock.ModelName : null, 
                    MovementTypeName = s.StockMovementType != null ? s.StockMovementType.Name : null,
                    Quantity = s.Quantity
                },
                orderBy: q => q.OrderByDescending(x => x.Date),
                cancellationToken: cancellationToken);
            
            return Result<object>.Success(new
            {
                TotalStockModels = totalStockModels,
                TotalSerials = totalSerials,
                TotalActiveWarranties = totalActiveSerials,
                AttachedSerials = attachedSerials,
                RecentMovements = recentMovements?.Take(10).ToList()
            });
        }
    }
}
